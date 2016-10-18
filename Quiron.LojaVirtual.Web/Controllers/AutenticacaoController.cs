using Quiron.LojaVirtual.Dominio.Entidades;
using Quiron.LojaVirtual.Dominio.Repositorio;
using System.Web.Mvc;
using System.Web.Security;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class AutenticacaoController : Controller
    {
        private AdministradoresRepositorio repositorio = new AdministradoresRepositorio();
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new Administrador());
        }

        [HttpPost]
        public ActionResult Login(Administrador administrador, string returnUrl)
        {
            if(ModelState.IsValid)
            {
                Administrador admin = repositorio.ObterAdministrador(administrador);

                if(admin != null)
                {
                    if(!Equals(admin.Senha, administrador.Senha))
                    {
                        ModelState.AddModelError("", "Senha não confere");
                    }
                    else
                    {
                        FormsAuthentication.SetAuthCookie(admin.Login, false);

                        if (Url.IsLocalUrl(returnUrl) && !string.IsNullOrWhiteSpace(returnUrl) &&
                            returnUrl.StartsWith("/") && !returnUrl.StartsWith("//") &&
                            !returnUrl.StartsWith("/\\"))
                        {
                            return Redirect(returnUrl);
                        }

                        return RedirectToAction("Index", "Produto", new { area = "Administrativo" });
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Administrador não localizado");
                }
            }

            return View(new Administrador());
        }
    }
}