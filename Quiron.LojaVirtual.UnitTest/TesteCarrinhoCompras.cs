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
    }
}
