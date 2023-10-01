using Microsoft.AspNetCore.Mvc;
using FilmesApi.Models;
namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]

public class FilmeController : ControllerBase
{
    private static List<Filme> filmes = new List<Filme>();

    [HttpPost]
    public void AdicionarFilme([FromBody] Filme filme)
    {
        filmes.Add(filme);
       
    }
}