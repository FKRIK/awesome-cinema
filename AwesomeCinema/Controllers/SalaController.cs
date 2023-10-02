using AwesomeCinema.Data;
using AwesomeCinema.Models;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeCinema.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SalaController : ControllerBase
{
    private readonly AppDataContext _context;
    //private static List<Sala> salas = new List<Sala>();
    //public static int Incremento = 0;

    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar([FromBody]Sala sala)
    {   
        try
        {
            _context.Add(sala);
            _context.SaveChanges();
            return Created("", sala);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        
    }

    [HttpGet]
    [Route("listar")]
    public IActionResult Listar()
    {
        try
        {
            List<Sala> salas = _context.Salas.ToList();
            return Ok(salas);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("listar/{isDisponivel}")]
    public IActionResult ListarPorDisponibilidade([FromRoute] bool isDisponivel)
    {
        try
        {
            List<Sala> salasFiltradas = new List<Sala>();
            foreach(Sala salaCadastrada in _context.Salas.ToList())
            {
                if(salaCadastrada.Disponivel == isDisponivel)
                {
                    salasFiltradas.Add(salaCadastrada);
                }
            }
            return Ok(salasFiltradas);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("listar/{assentos:int}")]
    public IActionResult ListarPorAssento([FromRoute] int assentos)
    {
        try
        {
            List<Sala> salasFiltradas = new List<Sala>();
            foreach(Sala salaCadastrada in _context.Salas.ToList())
            {
                if(salaCadastrada.Assentos >= assentos)
                {
                    salasFiltradas.Add(salaCadastrada);
                }
            }
            return Ok(salasFiltradas);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPatch]
    [Route("alterar/{id}")]
    public IActionResult AlterarDisponibilidade([FromRoute] int id, [FromBody] Sala salaCadastrada)
    {
        try
        {
            Sala salaDesejada = _context.Salas.FirstOrDefault(x => x.SalaId == id);

            if(salaDesejada.Disponivel == true)
            {
                salaDesejada.Disponivel = false;
            }
            else
            {
                salaDesejada.Disponivel = true;
            }
            _context.Salas.Update(salaCadastrada);
            _context.SaveChanges();
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route("deletar/{id}")]
    public IActionResult RemoverSala([FromRoute] int id)
    {
        try
        {
            Sala salasCadastrada = _context.Salas.Find(id);

            _context.Salas.Remove(salasCadastrada);
            _context.SaveChanges();
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}