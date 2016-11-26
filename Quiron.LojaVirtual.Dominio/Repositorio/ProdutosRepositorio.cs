using Quiron.LojaVirtual.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;

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
                    prod.Imagem = produto.Imagem;
                    prod.ImagemMimeType = produto.ImagemMimeType;
                }
            }

            context.SaveChanges();

        }

        public Produto Excluir(int produtoId)
        {
            Produto prod = context.Produtos.Find(produtoId);

            if (prod != null)
            {
                context.Produtos.Remove(prod);
                context.SaveChanges();
            }

            return prod;
        }

        public Produto ObterProduto(int id)
        {
            return context.Produtos.Single(p => p.ProdutoId == id);
        }
    }
}
