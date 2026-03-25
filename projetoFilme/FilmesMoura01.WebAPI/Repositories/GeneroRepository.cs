using FilmesMoura01.WebAPI.BdContextFilme;
using FilmesMoura01.WebAPI.Interfaces;
using FilmesMoura01.WebAPI.Models;

namespace FilmesMoura01.WebAPI.Repositories;

public class GeneroRepository : IGeneroRepository
{
    private readonly FilmeContext _context;

    public GeneroRepository(FilmeContext context)
    { 
        _context = context;
    
    }

    public void AtualizarIdCorpo(Genero generoAtualizado)
    {
        try
        {
            Genero generoBuscado = _context.Generos.Find
                (generoAtualizado.IdGenero)!;

            if(generoBuscado != null)
            {
                generoBuscado.Nome = generoAtualizado.Nome;            
            
            }
            _context.Generos.Update(generoBuscado!);
            _context.SaveChanges();
            
        
        }


        catch (Exception e)
        {

            throw;
        }
    }

    public void AtualizarIdUrl(Guid id, Genero generoAtualizado)
    {
        try
        {
            Genero generoBuscado = _context.Generos.Find
                  (id.ToString())!;

            if(generoBuscado != null)
            {
                generoBuscado.Nome = generoAtualizado.Nome;
            }

            _context.Generos.Update(generoBuscado!);
            _context.SaveChanges();
        }
        catch(Exception)
        {
            throw;
        }
    }

    public Genero BuscarPorId(Guid Id)
    {
        try
        {
            Genero generoBuscado = _context.Generos.Find(Id.ToString())!;
            return generoBuscado;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Cadastrar(Genero novoGenero)
    {
        try
        {
            novoGenero.IdGenero = Guid.NewGuid().ToString();   
            _context.Generos.Add(novoGenero);
            _context.SaveChanges();
        
        }
        catch(Exception)

        {
            throw;
        }
    }

    public void Deletar(Guid Id)
    {
        try
        {
            Genero generoBuscado = _context.Generos.Find(Id.ToString())!;
            if(generoBuscado != null)
            {
                _context.Generos.Remove(generoBuscado);
            }
            _context.SaveChanges();
        }
        catch (Exception)
        {

            throw;
        }
    }

    public List<Genero> Listar()
    {
       try
        {
            List<Genero> ListaGeneros = _context.Generos.ToList();
            return ListaGeneros;
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
