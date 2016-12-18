using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Web.HtmlHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Quiron.LojaVirtual.Web.V2.Controllers
{
    public class MenuController : Controller
    {
        private readonly CategoriasRepositorio repositorio = new CategoriasRepositorio();

        // GET: Categoria
        public ActionResult Index()
        {
            return View();
        }

        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Server, VaryByParam = "none")]
        public JsonResult ObterEsportes()
        {
            var obterCategoria = repositorio.ObterCategorias();

            var categoria = from c in obterCategoria
                            select new
                            {
                                c.CategoriaDescricao,
                                CategoriaDescricaoSeo = c.CategoriaDescricao.ToSeoUrl(),
                                c.CategoriaCodigo
                            };

            return Json(categoria, JsonRequestBehavior.AllowGet);
        }
    }
}