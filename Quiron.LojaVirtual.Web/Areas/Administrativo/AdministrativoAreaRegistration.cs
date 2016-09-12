using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.Areas.Administrativo
{
    public class AdministrativoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Administrativo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            /*Quiron.LojaVirtual.Web.Areas.Administrativo.Controllers é a adição de um namespace para ser verificado
             os Controllers, pois se tiver um controller com o mesmo nome na raiz do projeto dará erro*/
            context.MapRoute(
                "Administrativo_default",
                "Administrativo/{controller}/{action}/{id}",
                new { controller = "Produto", action = "Index", id = UrlParameter.Optional },
                new[] { "Quiron.LojaVirtual.Web.Areas.Administrativo.Controllers" }
            );
        }
    }
}