using AwesomeCinema.Data;
using AwesomeCinema.Models;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeCinema.Controllers;

[ApiController]
[Route("api/filme")]

public class FilmeController : ControllerBase
{
    private readonly AppDataContext _ctx;
    public FilmeController(AppDataContext ctx)
    {
        _ctx = ctx;
    }
    private static List<Filme> filmes = new List<Filme>();
    public static int id = 0;

    [HttpPost]
    [Route("cadastrar")]
    public void CadastrarFilme([FromBody] Filme filme)
    {
        filme.FilmeId = id++;
        filmes.Add(filme);
    }

    [HttpGet]
    [Route("listar")]
    public List<Filme> ListarFilme()
    {
        return filmes;
        
    }

    // [HttpGet]
    // [Route("listar/{emcartaz:bool}")]
    // public IActionResult ListarEmCartaz()
    // {
    //     try
    //     {
    //         List<Filme> filmes = _ctx.Filmes.ToList();
    //         return filmes. != false ? Ok (filmes) : Notfound();
    //     }
    //     catch (Exception e)
    //     {
    //         return BadRequest(e.Message);
    //     }
    // }

    [HttpGet]
    [Route("listar/{anolancamento}")]
    public List<Filme> ListarAnoLancamento([FromRoute] string anolancamento)
    {
        List<Filme> filmeFiltrado = new List<Filme>();

        foreach(Filme filmeCadastrado in filmes)
        {
            if(filmeCadastrado.EmCartaz != false)
            {
                filmeFiltrado.Add(filmeCadastrado);
            }
        }

        return filmeFiltrado;
    }

}