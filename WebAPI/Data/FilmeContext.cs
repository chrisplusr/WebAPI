using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data;

/*
    Abstração de Banco de Dados: O DbContext fornece uma camada de abstração sobre o banco de dados.
     Isso significa que você pode trabalhar com objetos e classes em vez de escrever SQL puro. 
     Isso torna o código mais orientado a objetos :)
     DbContext permite mapear objetos de classe em entidades de banco de dados.
     DbContext pode realizar diversas operações no banco e uma delas é a de escrita.
*/

//se não declarar a classe como pública, ela fica com o acesso internal
public class FilmeContext : DbContext 
{
    public FilmeContext(DbContextOptions<FilmeContext> options) : base(options) {}

    public DbSet<Filme> Filmes { get; set; }
}