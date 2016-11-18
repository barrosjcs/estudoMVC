using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class ClienteController : Controller
    {
        [Route("Teste")]
        public ActionResult Index()
        {
            ViewBag.Controller = "Cliente";
            ViewBag.Action = "Index";
            return View();
        }

        /* [Route] => Attribute Route é a definição da rota explicitamente no controle.
         Mas para usa-lo é necessário colocar no fonte de rota a instrução routes.MapMvcAttributeRoutes().
         Com isso não é necessário colocar a rota no fonte de rota*/
        [Route("Usuario/Adicionar/{usuario}/{id}")]
        public string Adicionar(int id, string usuario)
        {
            return string.Format("Usuário: {0}; Id: {1}", usuario, id);
        }
    }
}