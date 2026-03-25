using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interface;

public class ComentarioEventoRepository : IComentarioEventoRepository 
{
    private readonly EventContext _context;

    public ComentarioEventoRepository(EventContext context)
    {
        _context = context;
    }

    public void Cadastrar(ComentarioEvento comentario)
    {
        _context.ComentarioEventos.Add(comentario);
        _context.SaveChanges();
    }



    public void Deletar(Guid IdComentario)
    {
        var comentarioBuscado = _context.ComentarioEventos.Find(IdComentario);
        if (comentarioBuscado != null)
        {
            _context.ComentarioEventos.Remove(comentarioBuscado);
            _context.SaveChanges();
        }

    }


    public List<ComentarioEvento> ListarSomenteExibe(Guid IdEvento)
    {
        return _context.ComentarioEventos
            .Where(c => c.IdEvento == IdEvento && c.Exibe)
            .OrderByDescending(c => c.DataComentarioEvento)
            .ToList();
    }

    public List<ComentarioEvento> List(Guid IdEvento)
    {
        return _context.ComentarioEventos.Where(c => c.IdEvento == IdEvento).ToList();
    }

    public ComentarioEvento BuscarPorIdUsuario(Guid IdUsuario, Guid IdEvento)
    {
        throw new NotImplementedException();
    }
}


