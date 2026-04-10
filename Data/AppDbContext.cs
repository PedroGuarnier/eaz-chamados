using Microsoft.EntityFrameworkCore;
using EAZ.Chamados.Models;

namespace EAZ.Chamados.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Chamado> Chamados { get; set; }
}
