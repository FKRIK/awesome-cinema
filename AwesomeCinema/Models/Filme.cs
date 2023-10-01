using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models;
public class Filme
{
    [Required (ErrorMessage = "O Titulo do Filme é obrigatório!")]
    public string Titulo { get; set; }
    [Required (ErrorMessage = "A Duraçao do Filme é obrigatória!")]
    [MaxLength(300, ErrorMessage = "A duraçao maxima do filme nao pode ultrapassar 4 horas.")]
    public int Duracao { get; set; }    
    public string AnoLancamento { get; set; }
    public float Avaliacao { get; set; }
    public bool EmCartaz { get; set; }

}

