using LojaGame.Model;

namespace LojaGame.Service
{
    public interface ICategoriaService
    {
        Task<IEnumerable<Categoria>> GetAll(); //é uma classe no .NET Framework que realiza tarefas assincronas

        Task<Categoria?> GetById(long id);

        Task<IEnumerable<Categoria>> GetByTipo(string tipo);

        Task<Categoria?> Create(Categoria categoria);

        Task<Categoria?> Update(Categoria categoria);

        Task Delete(Categoria categoria);
    }
}
