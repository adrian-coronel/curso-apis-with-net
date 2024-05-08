using curso_apis_with_net.DBContext;
using curso_apis_with_net.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace curso_apis_with_net.Services.Implements
{
    public class CategoriaService : ICategoriaService
    {

        private readonly TareasContext context;

        public CategoriaService(TareasContext context)
        {
            this.context = context;
        }

        public IEnumerable<Categoria> Get()
        {
            return context.Categorias;
        }

        public async Task Save(Categoria categoria)
        {
            context.Add(categoria);
            await context.SaveChangesAsync();
        }

        public async Task Update(Guid id, Categoria categoria)
        {
            Categoria categoriaFind = await context.Categorias.FirstAsync(c => c.CategoriaId == id);

            if (categoriaFind == null) return;
            
            categoriaFind.Nombre = categoria.Nombre;
            categoriaFind.Descripcion = categoria.Descripcion;
            categoriaFind.Peso = categoria.Peso;

            await context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            Categoria categoriaFind = await context.Categorias.FirstAsync(c => c.CategoriaId == id);

            if (categoriaFind == null) return;

            context.Remove(categoriaFind);
            await context.SaveChangesAsync();
        }
    }
}
