using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using EventPlus.WebAPI.Utils;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositores;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly EventContext _context;

    public UsuarioRepository(EventContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Busca o usuario por Email e vailda o hash da senha
    /// </summary>
    /// <param name="Email"></param>
    /// <param name="Senha"></param>
    /// <returns>Usuario buscado e validado</returns>
    public Usuario BuscarPorEmailESenha(string Email, string Senha)
    {
        var usuarioBuscado = _context.Usuarios
             .Include(usuario => usuario.IdTipoUsuarioNavigation)
             .FirstOrDefault(usuario => usuario.Email == Email);

        //verifica se o usuario realmente existe

        if(usuarioBuscado != null)
        {
            //compara o hash da senha digitada com oq esta no banco 
            bool confere = Criptografia.CompararHash(Senha, usuarioBuscado.Senha);

            if (confere)
            {
                return usuarioBuscado;
            }
        }

        return null!;
    }

    /// <summary>
    /// Busca um usuario pelo Id, incluindo os dados do seu tipo usuario
    /// </summary>
    /// <param name="IdUsuario">Id do ususario a ser buscado </param>
    /// <returns>Usuario buscado</returns>

    public Usuario BuscarPorId(Guid IdUsuario)
    {
        return _context.Usuarios
            .Include(usuario => usuario.IdTipoUsuarioNavigation)
            .FirstOrDefault(usuario => usuario.IdUsuario == IdUsuario)!;
    }

    /// <summary>
    /// Cadastra um novo usuario com a senha criptografada 
    /// </summary>
    /// <param name="usuario"></param>
    public void cadastar(Usuario usuario)
    {
        usuario.Senha = Criptografia.GerarHash(usuario.Senha);
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();

    }
}
