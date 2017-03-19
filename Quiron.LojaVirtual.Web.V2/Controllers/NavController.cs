using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Web.V2.Models;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.V2.Controllers
{
    public class NavController : Controller
    {
        private ProdutoModeloRepositorio repositorio = new ProdutoModeloRepositorio();
        private ProdutosViewModel model;
        // GET: Nav
        public ActionResult Index()
        {
            var produtos = repositorio.ObterProdutosVitrine();
            model = new ProdutosViewModel { Produtos = produtos };

            return View(model);
        }

        [Route("nav/{id}/{marca}")]
        public ActionResult ObterProdutosPorMarca(string id)
        {
            var model = new ProdutosViewModel { Produtos = null };

            return View("Index", model);
        }
    }
}