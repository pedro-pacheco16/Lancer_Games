using LojaGame.Model;

namespace LojaGame.Service
{
    public interface IProdutoService
    {
       
        Task<IEnumerable<Produto>> GetAll();

        Task<Produto?> GetById(long id);

        Task<IEnumerable<Produto>> GetByNome(string nome);

        Task<IEnumerable<Produto>> GetByConsole(string console);

        Task<IEnumerable<Produto>> GetByPreco(decimal preco);

        Task<Produto?> Create(Produto produto);

        Task<Produto?> Update(Produto produto);

        Task Delete(Produto produto);
    }
}

