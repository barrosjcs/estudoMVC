using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiron.LojaVirtual.Dominio.Entidades;
using System.Linq;

namespace Quiron.LojaVirtual.UnitTest
{
    /// <summary>
    /// Summary description for TesteCarrinhoCompras
    /// </summary>
    [TestClass]
    public class TesteCarrinhoCompras
    {
        //Teste de adiocinar itens ao carrinho
        [TestMethod]
        public void AdicionarItensAoCarrinho()
        {
            Produto produto1 = new Produto {
                ProdutoId = 1,
                Nome = "Teste 1"
            };
            Produto produto2 = new Produto {
                ProdutoId = 2,
                Nome = "Teste 2"
            };

            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1, 2);
            carrinho.AdicionarItem(produto2, 3);

            ItemCarrinho[] itens = carrinho.ItensCarrinho.ToArray();

            Assert.AreEqual(itens.Length, 2);

        }
        [TestMethod]
        public void AdicionarProdutoExistenteAoCarrinho()
        {
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste 1"
            };
            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste 2"
            };

            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 1);
            carrinho.AdicionarItem(produto1, 10);

            ItemCarrinho[] itens = carrinho.ItensCarrinho.OrderBy(c => c.Produto.ProdutoId).ToArray();

            Assert.AreEqual(itens[0].Quantidade, 11);
            Assert.AreEqual(itens[1].Quantidade, 1);
        }

        [TestMethod]
        public void RemoverItensCarrinho()
        {
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste 1"
            };
            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste 2"
            };
            Produto produto3 = new Produto
            {
                ProdutoId = 3,
                Nome = "Teste 3"
            };

            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 3);
            carrinho.AdicionarItem(produto3, 5);
            carrinho.AdicionarItem(produto2, 1);

            carrinho.RemoverItem(produto2);

            Assert.AreEqual(carrinho.ItensCarrinho.Where(c => c.Produto == produto2).Count(), 0);
        }

        [TestMethod]
        public void CalcularValorTotal()
        {
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste 1",
                Preco = 100M
            };
            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste 2",
                Preco = 50M
            };

            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 1);
            carrinho.AdicionarItem(produto1, 4);

            decimal resultado = carrinho.ObterValorTotal();
            Assert.AreEqual(resultado, 550M);
        }

        [TestMethod]
        public void LimparItensCarrinho()
        {
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste 1",
                Preco = 100M
            };
            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste 2",
                Preco = 50M
            };

            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 1);
            carrinho.AdicionarItem(produto1, 4);

            carrinho.LimparCarrinho();

            Assert.AreEqual(carrinho.ItensCarrinho.Count(), 0);
        }

    }
}
