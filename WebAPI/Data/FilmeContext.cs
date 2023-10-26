using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data;

class FilmeContext : DbContext 
{
    public FilmeContext(DbContextOptions<FilmeContext> options) : base(options) {}

    public DbSet<Filme> Filmes { get; set; }
}