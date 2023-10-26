using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data;

/*
    Abstração de Banco de Dados: O DbContext fornece uma camada de abstração sobre o banco de dados.
     Isso significa que você pode trabalhar com objetos e classes em vez de escrever SQL puro. 
     Isso torna o código mais orientado a objetos :)
     DbContext permite mapear objetos de classe em entidades de banco de dados.
*/

class FilmeContext : DbContext 
{
    public FilmeContext(DbContextOptions<FilmeContext> options) : base(options) {}

    public DbSet<Filme> Filmes { get; set; }
}