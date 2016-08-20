using Quiron.LojaVirtual.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class VitrineController : Controller
    {
        #region Variaveis e Propriedades

        private ProdutosRepositorio repositorio = new ProdutosRepositorio();
        private int ProdutosPagina = 3;

        #endregion

        // GET: Produtos
        public ActionResult ListaProdutos(int pagina = 1)
        {
            var produtos = repositorio.Produtos.OrderBy(p => p.Descricao).
                Skip((pagina - 1) * ProdutosPagina).Take(ProdutosPagina);

            return View(produtos);
        }
    }
}