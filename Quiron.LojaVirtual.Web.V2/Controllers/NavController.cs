using Quiron.LojaVirtual.Web.V2.Models;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.V2.Controllers
{
    public class NavController : Controller
    {
        // GET: Nav
        public ActionResult Index()
        {
            return View();
        }

        [Route("nav/{id}/{marca}")]
        public ActionResult ObterProdutosPorMarca(string id)
        {
            var model = new ProdutosViewModel { Produtos = null };

            return View("Index", model);
        }
    }
}