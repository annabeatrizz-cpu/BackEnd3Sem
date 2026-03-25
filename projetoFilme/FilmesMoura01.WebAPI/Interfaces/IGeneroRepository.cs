using FilmesMoura01.WebAPI.Models;

namespace FilmesMoura01.WebAPI.Interfaces;

public interface IGeneroRepository
{
    Genero BuscarPorId(Guid Id);

    List<Genero> Listar();
    void Cadastrar(Genero novoGenero);

    void Deletar(Guid Id);
    void AtualizarIdCorpo(Genero
        generoAtualizado);

    void AtualizarIdUrl(Guid id, Genero
        generoAtualizado);
}
