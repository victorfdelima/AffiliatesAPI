using AfiliadosAPI.Models;
using AfiliadosAPI.Repository;

namespace AfiliadosAPI.Service;

public class TransactionService
{
    private readonly TransactionRepositories _transactionRepository;

    public TransactionService(TransactionRepositories transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public void TransactionProcess(List<Transaction> transactions)
    {
        foreach (var transaction in transactions)
        {
            // Aqui você pode implementar a lógica de normalização e processamento da transação
            _transactionRepository.AddTransaction(transaction);
        }
    }

    public List<Transaction> GetAll()
    {
        return _transactionRepository.GetTransactions();
    }
}
