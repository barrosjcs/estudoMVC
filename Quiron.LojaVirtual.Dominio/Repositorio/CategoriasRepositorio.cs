using Quiron.LojaVirtual.Dominio.Entidades;
using Quiron.LojaVirtual.Dominio.Entidades.Vitrine;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<ClubesInternacionais> ObterClubesInternacionais()
        {
            return context.ClubesInternacionais.OrderBy(c => c.LinhaDescricao);
        }

        public IEnumerable<ClubesNacionais> ObterClubesNacionais()
        {
            return context.ClubesNacionais.OrderBy(c => c.LinhaDescricao);
        }

        public IEnumerable<Selecoes> ObterSelecoes()
        {
            return context.Selecoes.OrderBy(c => c.LinhaDescricao);
        }
    }
}
