using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConnectPlus.Models;

[Table("Contato")]
public partial class Contato
{
    [Key]
    public Guid IdContato { get; set; }

    [StringLength(100)]
    public string Nome { get; set; } = null!;

    [Column("forma_contato")]
    [StringLength(100)]
    public string FormaContato { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Imagem { get; set; } = null!;

    public Guid? IdTipoUsuario { get; set; }

    [ForeignKey("IdTipoUsuario")]
    [InverseProperty("Contatos")]
    public virtual TipoContato? IdTipoUsuarioNavigation { get; set; }
}
