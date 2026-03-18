using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositores;

public class EventoRepository : IEventoRepository
{

    private readonly EventContext _context;
    public EventoRepository(EventContext context)
    {
        _context = context;
    }
    public void Atualizar(Guid id, Evento evento)
    {
        var EventoBuscado = _context.TipoEventos.Find();

        if (EventoBuscado != null)
        {
            EventoBuscado.Titulo = EventoBuscado.Titulo;
         

            _context.SaveChanges();

        }
    }

    public Evento BuscarPorId(Guid id)
    {
        return _context.Eventos.Find(id)!;
    }

    public void Cadastrar(Evento evento)
    {
        _context.Eventos.Add(evento);
        _context.SaveChanges();
    }

    public void Cadastrar(EventoDTO novoEvento)
    {
        throw new NotImplementedException();
    }

    public void Deletar(Guid id)
    {
        var EventoBuscado = _context.Eventos.Find(id);

        if (EventoBuscado != null)
        {
            _context.Eventos.Remove(EventoBuscado);
            _context.SaveChanges();
        }
    }

    public List<Evento> Listar()
    {
        return _context.Eventos
                   .Include(e => e.IdTipoEventoNavigation)
                   .Include(e => e.IdInstituicaoNavigation)
                   .ToList();
    }

    /// <summary>
    /// Metods que lista eventos filtrando pelas presensas de um usuario
    /// </summary>
    /// <param name="IdUsuario">Id do usuario para a filtragem</param>
    /// <returns>Lista de eventos filtrados pelo usuario</returns>
    public List<Evento> ListarPorId(Guid IdUsuario)
    {
        return _context.Eventos
            .Include(e => e.IdTipoEventoNavigation)
            .Include(e => e.IdInstituicaoNavigation)
            .Where(e => e.Presencas.Any(p => p.IdUsuario == IdUsuario && p.Situacao == true)).ToList();
    }


    /// <summary>
    /// Metodo que busca os proximos eventos que irao acontecer
    /// </summary>
    /// <returns>Lista de proximos even</returns>
    public List<Evento> ListarProximos()
    {
        return _context.Eventos
            .Include(e => e.IdTipoEventoNavigation)
            .Include(e => e.IdInstituicaoNavigation)
            .Where(e => e.DataEvento >= DateTime.Now)
            .OrderBy(e => e.DataEvento)
            .ToList();
    }
}
