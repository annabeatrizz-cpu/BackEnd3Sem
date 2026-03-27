using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConnectPlus.Models;

[Table("Contatos")]
public partial class Contato1
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
    [InverseProperty("InverseIdTipoUsuarioNavigation")]
    public virtual Contato1? IdTipoUsuarioNavigation { get; set; }

    [InverseProperty("IdTipoUsuarioNavigation")]
    public virtual ICollection<Contato1> InverseIdTipoUsuarioNavigation { get; set; } = new List<Contato1>();
}
