using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiron.LojaVirtual.Dominio.Entidades;
using Quiron.LojaVirtual.Web.Controllers;
using System.Linq;
using System.Web.Mvc;
using Quiron.LojaVirtual.Web.Models;

namespace Quiron.LojaVirtual.UnitTest
{
    [TestClass]
    public class UnitTestCarrinhoController
    {
        [TestMethod]
        public void AdicionarItemAoCarrinho()
        {
            // arrange
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
            carrinho.AdicionarItem(produto1, 3);

            CarrinhoController controller = new CarrinhoController();

            // act

            controller.Adicionar(carrinho, 2, "");

            // assert

            Assert.AreEqual(carrinho.ItensCarrinho.Count(), 1);
            Assert.AreEqual(carrinho.ItensCarrinho.ToArray()[0].Produto.ProdutoId, 1);
        }

        [TestMethod]
        public void AdiocionoProdutoVoltaPataCategoria()
        {
            // arrange
            Carrinho carrinho = new Carrinho();
            CarrinhoController controller = new CarrinhoController();

            // act
            RedirectToRouteResult result = controller.Adicionar(carrinho, 2, "minhaurl");

            // assert
            Assert.AreEqual(result.RouteValues["action"], "Index");
            Assert.AreEqual(result.RouteValues["returnUrl"], "minhaurl");
        }

        [TestMethod]
        public void PossoVerConteudoCarrinho()
        {
            // arrange
            Carrinho carrinho = new Carrinho();
            CarrinhoController controller = new CarrinhoController();

            // act
            CarrinhoViewModel resultado = (CarrinhoViewModel)controller.Index(carrinho, "minhaUrl").ViewData.Model;

            //assert
            Assert.AreSame(resultado.Carrinho, carrinho);
            Assert.AreEqual(resultado.ReturnUrl, "minhaUrl");
        }
    }
}
