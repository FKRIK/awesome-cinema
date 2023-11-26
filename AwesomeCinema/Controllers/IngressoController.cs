using AwesomeCinema.Data;
using AwesomeCinema.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AwesomeCinema.Controllers;

[ApiController]
[Route("api/ingresso")]

public class IngressoController : ControllerBase
{
    private readonly AppDataContext _ctx;
    public IngressoController(AppDataContext ctx)
    {
        _ctx = ctx;
    }
    
    [HttpPost]
    [Route("cadastrar")]
    public IActionResult CadastrarIngresso([FromBody] Ingresso ingresso)
    {
        try
        {      
           Cliente? cliente = _ctx.Clientes.Find(ingresso.ClienteId);
           if (cliente == null) return NotFound();
          
           Exibicao? exibicao = _ctx.Exibicoes.Find(ingresso.ExibicaoId);
           if (exibicao == null) return NotFound();

           ingresso.Exibicao = exibicao;
           ingresso.Cliente = cliente;
          
            _ctx.Ingressos.Add(ingresso);
            _ctx.SaveChanges();
            return Created("", ingresso);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }

    }
     [HttpGet]
    [Route("listar")]
    public IActionResult ListarIngresso()
    {
        try
        {
            List<Ingresso> ingressos = _ctx.Ingressos
            .Include(e => e.Cliente).Include(e => e.Exibicao).Include(e => e.Exibicao.Filme).Include(e => e.Exibicao.Sala).ToList();
            return Ok(ingressos);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
        
        
    }
}
