namespace FilmesApi.Models;
public class Sala
{
    public int Id { get; set;} = 0;
    public int Assentos { get; set;}
    public bool Disponivel { get; set;}
    public DateTime CriadoEm { get; set;}

    public Sala()
    {
        CriadoEm = DateTime.Now;
    }
}
