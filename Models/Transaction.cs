namespace AfiliadosAPI.Models;

public enum TipoTransacao
{
    VendaProdutor = 1,
    VendaAfiliado = 2,
    ComissaoPaga = 3,
    ComissaoRecebida = 4
}

public class Transaction
{
    public int Id { get; set; }
    public TipoTransacao Tipo { get; set; }
    public DateTime Data { get; set; }
    public string Produto { get; set; }
    public decimal Valor { get; set; }
    public string Vendedor { get; set; }
}
