using AfiliadosAPI.Models;
using System.Collections.Generic;
using System.Linq;
using AfiliadosAPI.Context;
using Microsoft.EntityFrameworkCore;

namespace AfiliadosAPI.Repository;

public class TransactionRepositories
{
    private readonly ApplicationDbContext _context;

    public TransactionRepositories(ApplicationDbContext context)
    {
        _context = context;
    }

    public void AddTransaction(Transaction transaction)
    {
        _context.Transactions.Add(transaction);
        _context.SaveChanges();
    }

    public List<Transaction> GetTransactions()
    {
        return _context.Transactions.ToList();
    }
}
