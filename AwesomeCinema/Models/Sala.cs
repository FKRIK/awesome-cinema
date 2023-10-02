namespace AwesomeCinema.Models;
public class Sala
{
    public int SalaId { get; set;}
    public int Assentos { get; set;}
    public bool Disponivel { get; set;}
    public DateTime CriadoEm { get; set;}

    public Sala()
    {
        CriadoEm = DateTime.Now;
    }
}
