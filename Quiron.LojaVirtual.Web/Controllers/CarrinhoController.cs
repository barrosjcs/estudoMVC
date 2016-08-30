using Quiron.LojaVirtual.Dominio.Entidades;
using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class CarrinhoController : Controller
    {
        private Carrinho Carrinho
        {
            get
            {
                if (Session["Carrinho"] == null)
                    return new Carrinho();

                return (Carrinho)Session["Carrinho"];
            }

            set
            {
                Session["Carrinho"] = value;
            }
        }

        private ProdutosRepositorio repositorio = new ProdutosRepositorio();

        // GET: Carrinho
        public RedirectToRouteResult Adicionar(int produtoId, string returnUrl)
        {
            Produto produto = repositorio.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);

            if(produto != null)
            {
                Carrinho.AdicionarItem(produto, 1);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult Remover(int produtoId, string returnUrl)
        {
            Produto produto = repositorio.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);

            if(produto != null)
            {
                Carrinho.RemoverItem(produto);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CarrinhoViewModel
            {
                Carrinho = this.Carrinho,
                ReturnUrl = returnUrl
            });
        }
    }
}