namespace FilmesMoura01.WebAPI.DTO;

public class FilmesDTO
{
    public string Titulo { get; set; }
    public IFormFile? Imagem { get; set; }
    public Guid? IdGenero { get; set;}
}
