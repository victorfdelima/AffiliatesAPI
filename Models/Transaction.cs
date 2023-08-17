using System.ComponentModel.DataAnnotations;
using AfiliadosAPI.Models.DTO;

namespace AfiliadosAPI.Models;

public enum TypeTransaction
{
    VendaProdutor = 1,
    
    VendaAfiliado = 2,
}

public class Transaction
{
    public Transaction(int id, TypeTransaction tipo, DateTime data, string product, decimal valor, int? afiliateId, Afiliate afiliate, Seller seller)
    {
        Id = id;
        Tipo = tipo;
        Data = data;
        Product = product;
        Valor = valor;
        AfiliateId = afiliateId;
        Afiliate = afiliate;
        Seller = seller;
    }

    public Transaction(int id, TypeTransaction tipo, DateTime data, string product, decimal valor, string seller)
    {
        Id = id;
        Tipo = tipo;
        Data = data;
        Product = product;
        Valor = valor;
    }
    
    [Key]
    public int Id { get; set; }
    
    public TypeTransaction Tipo { get; set; }
    public DateTime Data { get; set; }
    public string Product { get; set; }
    public decimal Valor { get; set; }
        
    // Relacionamento com o Seller (Vendedor)
    public int SellerId { get; set; } 
    
    public Seller Seller { get; set; } 
        
    // Relacionamento com o Afiliado (Afiliate) para comissões
    public int? AfiliateId { get; set; } 
    
    public Afiliate Afiliate { get; set; }
}
