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
   
    [HttpPost]
    [Route("cadastrar")]
    public IActionResult CadastrarFilme([FromBody] Filme filme)
    {
        try
        {      
                        _ctx.Filmes.Add(filme);
            _ctx.SaveChanges();
            return Created("", filme);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }

    }

    [HttpGet]
    [Route("listar")]
    public IActionResult ListarFilme()
    {
        try
        {
            List<Filme> filmes = _ctx.Filmes.ToList();
            return Ok(filmes);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
        
        
    }

    [HttpGet]
    [Route("listar/emcartaz/{emcartaz}")]
    public IActionResult ListarEmCartaz([FromRoute] bool emcartaz)
    {
        try
        {
            List<Filme> filmesFiltrados = new List<Filme>();
            foreach(Filme filmeCadastrado in _ctx.Filmes.ToList())
            {
                if(filmeCadastrado.EmCartaz == emcartaz)
                {
                    filmesFiltrados.Add(filmeCadastrado);
                }
            }
        return Ok(filmesFiltrados);

        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }      
    }

    [HttpGet]
    [Route("listar/anolancamento/{anolancamento}")]
    public IActionResult ListarPorAno([FromRoute] string anolancamento)
    {        
        try
        {    
            List<Filme> filmesFiltrados = new List<Filme>();
            foreach(Filme filmeCadastrado in _ctx.Filmes.ToList())
            {
                if(filmeCadastrado.AnoLancamento == anolancamento)
                {
                    filmesFiltrados.Add(filmeCadastrado);
                }
            }
            return Ok(filmesFiltrados);             
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }      
    }

    [HttpGet]
    [Route("listar/avaliacao/{avaliacao:float}")]
    public IActionResult ListarPorAvaliacao([FromRoute] float avaliacao)
    {   
        try
        {      
            List<Filme> filmesFiltrados = new List<Filme>();
            foreach(Filme filmeCadastrado in _ctx.Filmes.ToList())
            {
                if(filmeCadastrado.Avaliacao >= avaliacao)
                {
                    filmesFiltrados.Add(filmeCadastrado);
                }
            }
            return Ok(filmesFiltrados);    
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }       
    }
    
    [HttpPatch]
    [Route("alterar/{id}")]
    public IActionResult AlterarAvaliacao([FromRoute] int id, Filme filme)
    {
        try
        {
            Filme filmeDesejado = _ctx.Filmes.FirstOrDefault(alt => alt.FilmeId == id);

            filmeDesejado.Avaliacao = filme.Avaliacao;
            _ctx.SaveChanges();
            return Ok(filmeDesejado);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }   
    }


    [HttpPatch]
    [Route("remover/{id}")]
    public IActionResult RemoverDeCartaz([FromRoute] int id, Filme filme)
    {
        try
        {
            Filme filmeDesejado = _ctx.Filmes.FirstOrDefault(alt => alt.FilmeId == id);

            filmeDesejado.EmCartaz = filme.EmCartaz;      
            _ctx.SaveChanges();
            return Ok(filmeDesejado);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }       
    } 

    [HttpDelete]
    [Route("deletar/{id}")]
    public IActionResult DeletarFilme([FromRoute] int id)
    {
        try
        {
            Filme filmeDesejado = _ctx.Filmes.FirstOrDefault(alt => alt.FilmeId == id);
       
            _ctx.Filmes.Remove(filmeDesejado);
            _ctx.SaveChanges();

            return Ok();

        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }                           
    } 
}
    

