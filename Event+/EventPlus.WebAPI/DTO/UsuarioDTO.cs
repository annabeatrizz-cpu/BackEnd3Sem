using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO;

public class UsuarioDTO
{

    [Required(ErrorMessage = "O nome so usuario e obrigatorio!")]
    public string? Nome { get; set; }
    public string? Email { get; set; }
    [Required(ErrorMessage = "O e-mail do usuario e obrigatorio!")]

    public string? Senha { get; set; }
    [Required(ErrorMessage = "A senha do usuario e obrigatorio!")]

    public Guid IdTipoUsuario { get; set; }

    
}

