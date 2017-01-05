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

        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Server, VaryByParam = "none")]
        public JsonResult ObterMarcas()
        {
            var obterMarcas = repositorio.ObterMarcas();

            var marcas = from m in obterMarcas
                         select new
                         {
                             m.MarcaDescricao,
                             MarcaDescricaoSeo = m.MarcaDescricao.ToSeoUrl(),
                             m.MarcaCodigo
                        };

            return Json(marcas, JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Server, VaryByParam = "none")]
        public JsonResult ObterClubesInternacionais()
        {
            var obterClubesInternacionais = repositorio.ObterClubesInternacionais();

            var clubes = from c in obterClubesInternacionais
                         select new
                         {
                             Clube = c.LinhaDescricao,
                             ClubeSeo = c.LinhaDescricao.ToSeoUrl(),
                             ClubeCodigo = c.LinhaCodigo
                         };

            return Json(clubes, JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Server, VaryByParam = "none")]
        public JsonResult ObterClubesNacionais()
        {
            var obterClubesNacionais = repositorio.ObterClubesNacionais();

            var clubes = from c in obterClubesNacionais
                         select new
                         {
                             Clube = c.LinhaDescricao,
                             ClubeSeo = c.LinhaDescricao.ToSeoUrl(),
                             ClubeCodigo = c.LinhaCodigo
                         };

            return Json(clubes, JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Server, VaryByParam = "none")]
        public JsonResult ObterSelecoes()
        {
            var obterSelecoes = repositorio.ObterSelecoes();

            var selecoes = from s in obterSelecoes
                         select new
                         {
                             Clube = s.LinhaDescricao,
                             ClubeSeo = s.LinhaDescricao.ToSeoUrl(),
                             ClubeCodigo = s.LinhaCodigo
                         };

            return Json(selecoes, JsonRequestBehavior.AllowGet);
        }
    }
}