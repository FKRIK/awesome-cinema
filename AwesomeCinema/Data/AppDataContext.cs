using AwesomeCinema.Models;
using Microsoft.EntityFrameworkCore;

namespace AwesomeCinema.Data;
public class AppDataContext : DbContext
{
    public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
    {

    }

    //Classes que vão se tornar tabelas no banco de dados
    public DbSet<Filme> Filmes { get; set; }
    public DbSet<Sala> Salas { get; set; }
    public DbSet<Exibicao> Exibicoes { get; set; }
    public DbSet<Ingresso> Ingressos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }

}