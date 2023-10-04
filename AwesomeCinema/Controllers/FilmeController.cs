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

    [HttpGet]
    [Route("listar/emcartaz/{emcartaz}")]

    public List<Filme> ListarEmCartaz([FromRoute] bool emcartaz)
    {
        List<Filme> filmesFiltrados = new List<Filme>();
        foreach(Filme filmeCadastrado in filmes)
        {
            if(filmeCadastrado.EmCartaz == emcartaz)
            {
                filmesFiltrados.Add(filmeCadastrado);
            }
        }
        return filmesFiltrados;

    }

    [HttpGet]
    [Route("listar/anolancamento/{anolancamento}")]
    public List<Filme> ListarPorAno([FromRoute] string anolancamento)
    {            
            List<Filme> filmesFiltrados = new List<Filme>();
            foreach(Filme filmeCadastrado in filmes )
            {
                if(filmeCadastrado.AnoLancamento == anolancamento)
                {
                    filmesFiltrados.Add(filmeCadastrado);
                }
            }
            return filmesFiltrados;             
    }

    [HttpGet]
    [Route("listar/avaliacao/{avaliacao:float}")]
    public List<Filme> ListarPorAvaliacao([FromRoute] float avaliacao)
    {            
            List<Filme> filmesFiltrados = new List<Filme>();
            foreach(Filme filmeCadastrado in filmes )
            {
                if(filmeCadastrado.Avaliacao >= avaliacao)
                {
                    filmesFiltrados.Add(filmeCadastrado);
                }
            }
            return filmesFiltrados;             
    }
    
    [HttpPatch]
    [Route("alterar/{id}")]
    public void AlterarAvaliacao([FromRoute] int id, Filme filme)
    {
        Filme filmeDesejado = filmes.FirstOrDefault(alt => alt.FilmeId == id);

        filmeDesejado.Avaliacao = filme.Avaliacao;
    }

    [HttpPatch]
    [Route("remover/{id}")]
    public void RemoverDeCartaz([FromRoute] int id, Filme filme)
    {
        Filme filmeDesejado = filmes.FirstOrDefault(alt => alt.FilmeId == id);

        filmeDesejado.EmCartaz = filme.EmCartaz;                     
    } 

    [HttpDelete]
    [Route("deletar/{id}")]
    public void DeletarFilme([FromRoute] int id)
    {
        Filme filmeDesejado = filmes.FirstOrDefault(alt => alt.FilmeId == id);

        filmes.Remove(filmeDesejado);                          
    } 
}
    

