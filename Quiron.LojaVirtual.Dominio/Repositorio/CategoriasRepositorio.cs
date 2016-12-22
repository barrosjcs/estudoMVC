using Quiron.LojaVirtual.Dominio.Entidades;
using Quiron.LojaVirtual.Dominio.Entidades.Vitrine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.Dominio.Repositorio
{
    public class CategoriasRepositorio
    {
        private readonly EfDbContext context = new EfDbContext();

        public IEnumerable<Categoria> ObterCategorias()
        {
            return context.Categorias.OrderBy(c => c.CategoriaDescricao);
        }
        public IEnumerable<MarcaVitrine> ObterMarcas()
        {
            return context.MarcaVitrine.OrderBy(m => m.MarcaDescricao);
        }
    }
}
