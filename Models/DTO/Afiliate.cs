using System.ComponentModel.DataAnnotations;

namespace AfiliadosAPI.Models.DTO;

public class Afiliate
{
    public Afiliate()
    {
        Name = Name;
        Balance = Balance;
    }
    
    [Key]
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public decimal Balance { get; set; }

    public ICollection<Transaction> ReceivedCommissions { get; set; } = new List<Transaction>();
}
