using Quiron.LojaVirtual.Dominio.Entidades;
using Quiron.LojaVirtual.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.Areas.Administrativo.Controllers
{
    public class ProdutoController : Controller
    {
        private ProdutosRepositorio repositorio = new ProdutosRepositorio();

        // GET: Administrativo/Produto
        public ActionResult Index()
        {
            var produtos = repositorio.Produtos;

            return View(produtos);
        }

        public ViewResult Alterar(int produtoId)
        {
            Produto produto = repositorio.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);
            return View(produto);
        }

        [HttpPost]
        public ActionResult Alterar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                repositorio.Salvar(produto);
                TempData["mensagem"] = string.Format("{0} foi salvo com sucesso", produto.Nome);

                return RedirectToAction("Index");
            }

            return View(produto);
        }
    }
}