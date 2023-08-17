using AfiliadosAPI.Models;
using System.Collections.Generic;
using System.Linq;
using AfiliadosAPI.Context;
using AfiliadosAPI.Interfaces;
using AfiliadosAPI.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace AfiliadosAPI.Repository;

public class SellerRepositories
{
    private readonly ApplicationDbContext _context;
    
    protected SellerRepositories(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task UpdateAsync(Seller seller)
    {
        _context.Sellers.Update(seller);
        await _context.SaveChangesAsync();
    }

    public async Task AddAsync(Seller seller)
    {
        _context.Sellers.AddAsync(seller);
        await _context.SaveChangesAsync();
    }
}
