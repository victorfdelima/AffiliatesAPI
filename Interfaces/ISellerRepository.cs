using AfiliadosAPI.Models.DTO;

namespace AfiliadosAPI.Interfaces;

public interface ISellerRepository
{
    Task<Seller> GetByNameAsync(string name);
}

