using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO;

public class InstituicaoDTO
{
    [Required(ErrorMessage = "O NomeFantasia do Instituicao e obrigatorio!")]
    public string? NomeFantasia{ get; set; }


    [Required(ErrorMessage = "O CNPJ da Instituicao e obrigatorio!")]
    public string? CNPJ { get; set; }

    [Required(ErrorMessage = "O Endereço da Instituicao e obrigatorio!")]
    public string? Endereço { get; set; }
}
