using AwesomeCinema.Data;
using AwesomeCinema.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AwesomeCinema.Controllers;

[ApiController]
[Route("api/cliente")]

public class ClienteController : ControllerBase
{
    private readonly AppDataContext _ctx;
    public ClienteController(AppDataContext ctx)
    {
        _ctx = ctx;
    }
       
    [HttpPost]
    [Route("cadastrar")]
    public IActionResult CadastrarCliente([FromBody] Cliente cliente)
    {
        try
        {                         
            _ctx.Clientes.Add(cliente);
            _ctx.SaveChanges();
            return Created("", cliente);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }

    }    

    [HttpGet]
    [Route("listar")]
    public IActionResult ListarCliente()
    {
        try
        {
            List<Cliente> clientes = _ctx.Clientes.ToList();
            return Ok(clientes);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
              
    }
    [HttpPatch]
    [Route("alterar/{id}")]
    public IActionResult AlterarCliente([FromRoute] int id, Cliente cliente)
    {
        try
        {
            Cliente clienteCadastrado = _ctx.Clientes.FirstOrDefault(alt => alt.ClienteId == id);

            clienteCadastrado.Nome = cliente.Nome;
            clienteCadastrado.Cpf = cliente.Cpf;
            _ctx.SaveChanges();
            return Ok(clienteCadastrado);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }   
    }

    [HttpDelete]
    [Route("deletar/{id}")]
    public IActionResult RemoverCliente([FromRoute] int id)
    {
        try
        {
            Cliente clienteCadastrado = _ctx.Clientes.FirstOrDefault(alt => alt.ClienteId == id);
       

           _ctx.Clientes.Remove(clienteCadastrado);
            _ctx.SaveChanges();
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
