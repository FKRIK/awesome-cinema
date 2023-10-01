using System.Diagnostics.Metrics;
using System.Net;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FilmesApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SalaController : ControllerBase
{
    private static List<Sala> salas = new List<Sala>();
    public static int Incremento = 0;

    [HttpPost]
    [Route("cadastrar")]
    public void Cadastrar([FromBody]Sala sala)
    {   
        sala.Id = Incremento++;
        salas.Add(sala);
    }

    [HttpGet]
    [Route("listar")]
    public List<Sala> Listar()
    {
        return salas;
    }

    [HttpGet]
    [Route("listar/{isDisponivel}")]
    public List<Sala> ListarPorDisponibilidade([FromRoute] bool isDisponivel)
    {
        List<Sala> salasFiltradas = new List<Sala>();

        foreach(Sala salaCadastrada in salas)
        {
            if(salaCadastrada.Disponivel == isDisponivel)
            {
                salasFiltradas.Add(salaCadastrada);
            }
        }
        
        return salasFiltradas;
    }

    [HttpGet]
    [Route("listar/{assentos:int}")]
    public List<Sala> ListarPorAssento([FromRoute] int assentos)
    {
        List<Sala> salasFiltradas = new List<Sala>();

        foreach(Sala salaCadastrada in salas)
        {
            if(salaCadastrada.Assentos >= assentos)
            {
                salasFiltradas.Add(salaCadastrada);
            }
        }

        return salasFiltradas;
    }

    [HttpPatch]
    [Route("alterar/{id}")]
    public void AlterarDisponibilidade([FromRoute] int id)
    {
        Sala salaDesejada = salas.FirstOrDefault(x => x.Id == id);

        if(salaDesejada.Disponivel == true)
        {
            salaDesejada.Disponivel = false;
        }

        salaDesejada.Disponivel = true;
    }

    [HttpDelete]
    [Route("deletar/{id}")]
    public void RemoverSala([FromRoute] int id)
    {
        Sala salasCadastrada = salas.Find(x => x.Id == id);

        salas.Remove(salasCadastrada);
    }
}