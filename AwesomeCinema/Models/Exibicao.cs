namespace AwesomeCinema.Models;
public class Exibicao
{
    public int ExibicaoId { get; set;}
    public DateTime DataHora { get; set; }
    public Filme? Filme { get; set; }
    public int FilmeId { get; set; }
    public Sala? Sala { get; set; }
    public int SalaId { get; set; }

}
