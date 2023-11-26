using AwesomeCinema.Data;
using AwesomeCinema.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AwesomeCinema.Controllers;

[ApiController]
[Route("api/exibicao")]

public class ExibicaoController : ControllerBase
{
    private readonly AppDataContext _ctx;
    public ExibicaoController(AppDataContext ctx)
    {
        _ctx = ctx;
    }
   
    [HttpPost]
    [Route("cadastrar")]
    public IActionResult CadastrarExibicao([FromBody] Exibicao exibicao)
    {
        try
        {
           Filme? filme = _ctx.Filmes.Find(exibicao.FilmeId);
           if (filme == null) return NotFound();
          
           Sala? sala = _ctx.Salas.Find(exibicao.SalaId);
           if (sala == null) return NotFound();

           exibicao.Filme = filme;
           exibicao.Sala = sala;
          
            _ctx.Exibicoes.Add(exibicao);
            _ctx.SaveChanges();
            return Created("", exibicao);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [Route("listar")]
    public IActionResult ListarExibicao()
    {
        try
        {
            List<Exibicao> exibicoes = _ctx.Exibicoes
            .Include(e => e.Filme).Include(e => e.Sala).ToList();
            return Ok(exibicoes);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
        
        
    }
    [HttpPatch]
    [Route("alterar/{id}")]
    public IActionResult Alterar([FromRoute] int id, Exibicao exibicao)
    {
        try
        {
            Exibicao? exibicaoCadastrada = _ctx.Exibicoes.FirstOrDefault(alt => alt.ExibicaoId == id);
            if(exibicaoCadastrada == null) return NotFound();
            exibicaoCadastrada.DataHora = exibicao.DataHora;
            exibicaoCadastrada.FilmeId = exibicao.FilmeId;
            exibicaoCadastrada.SalaId = exibicao.SalaId;
            _ctx.SaveChanges();
            return Ok(exibicaoCadastrada);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }   
    }
    [HttpDelete]
    [Route("deletar/{id}")]
    public IActionResult DeletarExibicao([FromRoute] int id)
    {
        try
        {
            Exibicao? exibicaoCadastrada = _ctx.Exibicoes.FirstOrDefault(alt => alt.ExibicaoId == id);
       
            _ctx.Exibicoes.Remove(exibicaoCadastrada);
            _ctx.SaveChanges();

            return Ok();

        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }                           
    } 
}