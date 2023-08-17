using AfiliadosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AfiliadosAPI.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Transaction> Transactions { get; set; }

    // Defina outras DbSets para outras entidades, se necessário

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configurações de mapeamento das entidades para tabelas, chaves primárias, índices, etc.

        base.OnModelCreating(modelBuilder);
    }
}
