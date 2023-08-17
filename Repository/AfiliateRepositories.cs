using AfiliadosAPI.Models;
using System.Collections.Generic;
using System.Linq;
using AfiliadosAPI.Context;
using AfiliadosAPI.Interfaces;
using AfiliadosAPI.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace AfiliadosAPI.Repository;

public class AfiliateRepositories
{
    private readonly ApplicationDbContext _context;
    
    protected AfiliateRepositories(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task UpdateAsync(Afiliate afiliate)
    {
        _context.Afiliates.Update(afiliate);
        await _context.SaveChangesAsync();
    }
    
    public async Task AddAsync(Afiliate afiliate)
    {
        _context.Afiliates.AddAsync(afiliate);
        await _context.SaveChangesAsync();
    }
}
