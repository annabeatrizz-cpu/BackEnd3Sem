
using ConnectPlus.BdContextConnect;
using ConnectPlus.Interface; // Ajuste conforme seu namespace de interfaces
using ConnectPlus.Models;

namespace ConnectPlus.Repository
{
    public class TipoContatoRepository : ITipoContatoRepository
    {
        private readonly ConnectContext _context;


        public TipoContatoRepository(ConnectContext context)
        {
            _context = context;
        }

        public List<TipoContato> Listar()
        {
            // Retorna todos os registros da tabela
            return _context.TipoContatos.ToList();
        }

        public TipoContato BuscarPorId(Guid id)
        {
            // Busca pela chave primária
            return _context.TipoContatos.Find(id)!;
        }

        public void Cadastrar(TipoContato tipoContato)
        {
            _context.TipoContatos.Add(tipoContato);
            _context.SaveChanges(); // Salva as alterações no banco
        }

        public void Atualizar(Guid id, TipoContato tipoContato)
        {
            var tipoContatoBuscado = _context.TipoContatos.Find(id);

            if (tipoContatoBuscado != null)
            {
                // Atualize aqui os campos necessários. Exemplo:
                // tipoContatoBuscado.Nome = tipoContato.Nome;

                tipoContatoBuscado.Titulo = tipoContato.Titulo;
                _context.SaveChanges();
            }
        }

        public void Deletar(Guid id)
        {
            var tipoContatoBuscado = _context.TipoContatos.Find(id);

            if (tipoContatoBuscado != null)
            {
                _context.TipoContatos.Remove(tipoContatoBuscado);
                _context.SaveChanges();

            }
        }
    }
}