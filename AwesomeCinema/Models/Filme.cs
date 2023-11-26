namespace AwesomeCinema.Models;
public class Filme
{
    public int FilmeId { get; set; }
    public string? Titulo { get; set; }
    public int Duracao { get; set; }    
    public string? AnoLancamento { get; set; }
    public float Avaliacao { get; set; }
    public bool EmCartaz { get; set; }
    public DateTime CriadoEm { get; set; }

    public Filme()
    {
        EmCartaz = true;
        CriadoEm = DateTime.Now;
    }
}

