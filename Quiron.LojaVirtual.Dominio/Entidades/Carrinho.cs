using System.Collections.Generic;
using System.Linq;

namespace Quiron.LojaVirtual.Dominio.Entidades
{
    public class Carrinho
    {
        private readonly List<ItemCarrinho> itensCarrinho = new List<ItemCarrinho>();
        public void AdicionarItem(Produto produto, int quantidade)
        {
            ItemCarrinho itemCarrinho = itensCarrinho.FirstOrDefault(p => p.Produto.ProdutoId == produto.ProdutoId);

            if(itemCarrinho == null)
            {
                itensCarrinho.Add(new ItemCarrinho
                {
                    Produto = produto,
                    Quantidade = quantidade
                });
            }
            else
            {
                itemCarrinho.Quantidade = quantidade;
            }
        }

        public void RemoverItem(Produto produto)
        {
            itensCarrinho.RemoveAll(p => p.Produto.ProdutoId == produto.ProdutoId);
        }

        public decimal ObterValorTotal()
        {
            return itensCarrinho.Sum(p => p.Produto.Preco * p.Quantidade);
        }

        public void LimparCarrinho()
        {
            itensCarrinho.Clear();
        }

        public IEnumerable<ItemCarrinho> ItensCarrinho
        {
            get { return itensCarrinho; }
        }
    }

    public class ItemCarrinho
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
    }
}
