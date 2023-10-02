using Microsoft.EntityFrameworkCore;
using FilmesApi.Models;
namespace API.Data;
public class AppDataContext : DbContext
{
    public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
    {

    }

    //Classes que vão se tornar tabelas no banco de dados
    public DbSet<Filme> Filmes { get; set; }

}