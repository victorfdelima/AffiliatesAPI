using AfiliadosAPI.Models.DTO;

namespace AfiliadosAPI.Interfaces;

public interface IAfiliateRepository
{
    Task<Afiliate> GetByNameAsync(string name);

    Task AddAsync(Afiliate afiliate);
    
    Task UpdateAsync(Afiliate afiliate);
}