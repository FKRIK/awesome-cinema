namespace AwesomeCinema.Models;
public class Ingresso
{
    public int IngressoId { get; set;}

    public Cliente? Cliente { get; set; }
    public int ClienteId { get; set; }
    public Exibicao? Exibicao { get; set; }
    public int ExibicaoId { get; set; }

}