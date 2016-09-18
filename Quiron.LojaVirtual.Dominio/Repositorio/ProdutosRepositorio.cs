using Quiron.LojaVirtual.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.Dominio.Repositorio
{
    public class ProdutosRepositorio
    {
        private readonly EfDbContext context = new EfDbContext();
        public IEnumerable<Produto> Produtos
        {
            get { return context.Produtos; }
        }

        //Salvar e alterar
        public void Salvar(Produto produto)
        {
            if(produto.ProdutoId == 0)
            {
                // Salvar
                context.Produtos.Add(produto);
            }
            else
            {
                //Alterar
                Produto prod = context.Produtos.Find(produto.ProdutoId);
                if(prod != null)
                {
                    prod.Nome = produto.Nome;
                    prod.Descricao = produto.Descricao;
                    prod.Preco = produto.Preco;
                    prod.Categoria = produto.Categoria;
                }
            }

            context.SaveChanges();
        }
    }
}
