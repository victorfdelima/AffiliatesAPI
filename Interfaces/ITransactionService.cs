using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AfiliadosAPI.Interfaces;

public interface ITransactionService
{
    Task<bool> ProcessUploadedTransactionsAsync(IFormFile file);
}