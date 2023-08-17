using AfiliadosAPI.Models;
using AfiliadosAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace AfiliadosAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionController : ControllerBase
{
    private readonly TransactionService _transactionService;

    public TransactionController(TransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpPost("process")]
    public IActionResult ProcessTransactions([FromBody] List<Transaction> transactions)
    {
        _transactionService.TransactionProcess(transactions);
        return Ok();
    }

    [HttpGet("transactions")]
    public IActionResult GetAllTransactions()
    {
        var transactions = _transactionService.GetAll();
        return Ok(transactions);
    }
}
