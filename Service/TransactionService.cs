using System.Globalization;
using AfiliadosAPI.Models;
using AfiliadosAPI.Repository;
using AfiliadosAPI.Interfaces;
using AfiliadosAPI.Models.DTO;

namespace AfiliadosAPI.Service;

public class TransactionService
{
    private readonly TransactionRepositories _transactionRepository;
    private readonly AfiliateRepositories _afiliateRepository;
    private readonly SellerRepositories _sellerRepository;
    private readonly ISellerRepository _isellerRepository;
    private readonly IAfiliateRepository _iAfiliateRepository;


    public TransactionService(TransactionRepositories transactionRepository, AfiliateRepositories afiliateRepository,
        SellerRepositories sellerRepository, ISellerRepository isellerRepository, IAfiliateRepository iAfiliateRepository)
    {
        _transactionRepository = transactionRepository;
        _sellerRepository = sellerRepository;
        _afiliateRepository = afiliateRepository;
        _isellerRepository = isellerRepository;
        _iAfiliateRepository = iAfiliateRepository;
    }

    public void TransactionProcess(List<Transaction> transactions)
    {
        foreach (var transaction in transactions)
        {
            _transactionRepository.AddTransaction(transaction);
        }
    }

    public async Task<bool> NormalizeAndCalculateCommissionsAsync(IFormFile file)
    {
        try
        {
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (!reader.EndOfStream)
                {
                    var line = await reader.ReadLineAsync();
                    var fields = line?.Split('\t');
                    if (fields != null && fields[1].Contains("SALEANDCOMISSION"))
                    {
                        var sellerName = fields[3];
                        var seller = await _isellerRepository.GetByNameAsync(sellerName);

                        if (seller == null)
                        {
                            seller = new Seller
                            {
                                Name = sellerName,
                                Balance = 0
                            };
                            await _sellerRepository.AddAsync(seller);
                        }

                        var transaction = new Transaction(
                            id: 0,
                            tipo: TypeTransaction.VendaProdutor,
                            data: DateTime.Parse(fields[0]),
                            product: fields[1],
                            valor: decimal.Parse(fields[2], CultureInfo.InvariantCulture),
                            seller: sellerName
                        );

                        seller.Balance += transaction.Valor;
                        transaction.Seller.Balance = Convert.ToDecimal(TypeTransaction.ComissaoPaga);
                        await _transactionRepository.AddAsync(transaction);
                        await _sellerRepository.UpdateAsync(seller);
                    }
                    else // Venda de afiliados
                    {
                        var afiliateName = fields?[3];
                        var afiliate = await _iAfiliateRepository.GetByNameAsync(afiliateName);

                        if (afiliate == null)
                        {
                            afiliate = new Afiliate
                            {
                                Name = afiliateName,
                                Balance = 0 // Defina o saldo inicial conforme necessário
                            };
                            await _afiliateRepository.AddAsync(afiliate);
                        }

                        var transaction = new Transaction(
                            id: 0,
                            tipo: TypeTransaction.VendaAfiliado,
                            data: DateTime.Parse(fields[0]),
                            product: fields[1],
                            valor: decimal.Parse(fields[2], CultureInfo.InvariantCulture),
                            seller: afiliateName
                        );

                        afiliate.Balance += transaction.Valor * 0.1m; // Comissão de 10%
                        transaction.Afiliate.Balance = Convert.ToDecimal(TypeTransaction.ComissaoRecebida);
                        transaction.AfiliateId = afiliate.Id;
                        transaction.Afiliate = afiliate;

                        await _transactionRepository.AddAsync(transaction);
                        await _afiliateRepository.UpdateAsync(afiliate);
                    }
                }

                return true;
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public List<Transaction> GetAll()
    {
        return _transactionRepository.GetTransactions();
    }
}
