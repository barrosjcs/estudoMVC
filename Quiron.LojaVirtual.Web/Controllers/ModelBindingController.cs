using Quiron.LojaVirtual.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class ModelBindingController : Controller
    {
        // GET: ModelBinding
        public ActionResult Index()
        {
            return View(new Produto());
        }

        [HttpPost]
        public ActionResult Editar()
        {
            var produto = new Produto();

            /* O UpdateModel irá atualizar a entidade Produto automaticamente, passando para o objeto
             * os valores do form com o id de mesmo nome da propriedade. Porém poder ocorrer erro se 
             a entidade requerir alguma propriedade obrigatório e a View não passar */
            //UpdateModel(produto);

            /* O TryUpdateModel irá atualizar a entidade Produto automaticamente se possíevel, passando para o objeto
             * os valores do form com o id de mesmo nome da propriedade. */
            TryUpdateModel(produto);

            return RedirectToAction("Index");
        }
    }
}