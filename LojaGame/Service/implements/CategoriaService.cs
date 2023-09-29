using LojaGame.Model;
using Microsoft.EntityFrameworkCore;
using LojaGame.Data;

namespace LojaGame.Service.implements
{
    public class CategoriaService : ICategoriaService
    {
        private readonly AppDbContext _context;

        public CategoriaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categoria>> GetAll()
        {
            return await _context.Categorias
                .Include(c => c.produto)
                .ToListAsync(); 
        }

        public async Task<Categoria?> GetById(long id)
        {
            try
            {
                var Categoria = await _context.Categorias
                    .Include(c => c.produto)
                    .FirstAsync(i => i.id == id);

                return Categoria;


            }
            catch
            {
                return null;
            }
        }

        public async  Task<IEnumerable<Categoria>> GetByTipo(string tipo)
        {
            var categoria = await _context.Categorias
               .Include(c => c.produto)
               .Where(c => c.Tipo.Contains(tipo))
               .ToListAsync();

            return categoria; 
        }

        public async Task<Categoria?> Create(Categoria categoria)
        {
            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();

            return categoria;

        }

        public async Task Delete(Categoria categoria)
        {
            _context.Remove(categoria);
            await _context.SaveChangesAsync();
        }
        public async Task<Categoria?> Update(Categoria categoria)
        {
            var CategoriaUpdate = await _context.Categorias.FindAsync(categoria.id);

            if (CategoriaUpdate is null)
                return null;

            _context.Entry(CategoriaUpdate).State = EntityState.Detached;
            _context.Entry(categoria).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return categoria;
        }
    }
}
