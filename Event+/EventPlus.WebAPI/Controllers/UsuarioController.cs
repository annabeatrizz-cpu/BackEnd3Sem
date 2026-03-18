using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using EventPlus.WebAPI.Repositores;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioRepository usuarioRepository;
    private IUsuarioRepository _usuarioRepository;

    public UsuarioController(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }


    /// <summary>
    /// Endpoint API que faz a chamada de buscar um metodo por id
    /// </summary>
    /// <param name="id">id do usuario a ser buscado</param>
    /// <returns>status code 200 e usuario buscado</returns>
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_usuarioRepository.BuscarPorId(id));
        }
        catch(Exception error)
        {
            return BadRequest(error.Message);
        }
    }


    /// <summary>
    /// EndPoint da api que faz a chamada para o metodo de cadastrar o usuario
    /// </summary>
    /// <param name="usuario">Usuario a ser cadastrado</param>
    /// <returns>Status code 201 e usuario cadastrado</returns>
    [HttpPost]
    public IActionResult Cadastrar(UsuarioDTO usuario)
    {

        try
        {
            var novoUsuario = new Usuario
            {
               Nome = usuario.Nome!,
               Senha = usuario.Senha!,
               Email = usuario.Email!,
               IdTipoUsuario = usuario.IdTipoUsuario
            };

            _usuarioRepository.cadastar(novoUsuario);
            return StatusCode(201, novoUsuario);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }

    }

}
