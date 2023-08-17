using System.ComponentModel.DataAnnotations;

namespace AfiliadosAPI.Models.DTO;

public class Seller
{
    public Seller()
    {
        Name = Name;
        Balance = Balance;
    }

    [Key]
    public int Id { get; set; }
    
    public string? Name { get; set; }
    
    public decimal Balance { get; set; }

    public ICollection<Transaction> Sales { get; set; } = new List<Transaction>();
}
