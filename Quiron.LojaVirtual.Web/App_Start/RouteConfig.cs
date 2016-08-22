using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Quiron.LojaVirtual.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            /* Roteamento definido com seu controller e action(view). Assim não mostrará estas informações na Url.
               Se tornando uma visualização mais amigável.*/

            routes.MapRoute(
                name: null,
                //Padrão que a Url terá. Entre chaves é o parâmetro da action, neste caso, é da ProdutosViewModel
                url: "Pagina{pagina}",
                defaults: new { controller = "Vitrine", action = "ListaProdutos" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Vitrine", action = "ListaProdutos", id = UrlParameter.Optional }
            );
        }
    }
}
