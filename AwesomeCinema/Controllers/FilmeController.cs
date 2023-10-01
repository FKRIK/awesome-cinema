using Microsoft.AspNetCore.Mvc;
using FilmesApi.Models;
namespace FilmesApi.Controllers;

[ApiController]
[Route("api/filme")]

public class FilmeController : ControllerBase
{
    private static List<Filme> filmes = new List<Filme>();

    [HttpPost]
    [Route("cadastrar")]
    public void AdicionarFilme([FromBody] Filme filme)
    {
        filmes.Add(filme);
    }

    [HttpGet]
    [Route("listar")]
    public List<Filme> ListarFilme()
    {
        return filmes;
        
    }
}