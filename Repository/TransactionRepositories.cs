using AfiliadosAPI.Models;
using System.Collections.Generic;
using System.Linq;
using AfiliadosAPI.Context;
using AfiliadosAPI.Interfaces;
using AfiliadosAPI.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace AfiliadosAPI.Repository;

public abstract class TransactionRepositories
{
    private readonly ApplicationDbContext _context;

    protected TransactionRepositories(ApplicationDbContext context)
    {
        _context = context;
    }

    public void AddTransaction(Transaction transaction)
    {
        _context.Transactions.Add(transaction);
        _context.SaveChanges();
    }
    
    public async Task AddAsync(Transaction transaction)
    {
        _context.Transactions.Add(transaction);
        await _context.SaveChangesAsync();
    }

    public List<Transaction> GetTransactions()
    {
        return _context.Transactions.ToList();
    }
}
