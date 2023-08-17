using AfiliadosAPI.Models;

namespace AfiliadosAPI.Interfaces;

public interface ITransactionRepository
{
    Task AddAsync(Transaction transaction);
}