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

    [HttpGet("all")]
    public IActionResult GetAllTransactions()
    {
        var transactions = _transactionService.GetAll();
        return Ok(transactions);
    }

    [HttpPost("upload")]
    public async Task<IActionResult> UploadTransactions([FromForm] IFormFile? file)
    {
        //I've used pattern design instead of file == null
        if (file is not { Length: > 0 })
        {
            return BadRequest("Invalid file");
        }

        bool success = await _transactionService.NormalizeAndCalculateCommissionsAsync(file);

        if (success)
        {
            return Ok("Transactions processed successfully");
        }
        else
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred");
        }
    }
}
