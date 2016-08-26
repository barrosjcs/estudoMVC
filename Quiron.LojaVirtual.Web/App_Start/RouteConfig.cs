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
            // Listar os Produtos da página 1 com todas as categorias
            routes.MapRoute(null, "",
                new { controller = "Vitrine", action = "ListaProdutos", categoria = (string)null, pagina = 1 });

            // Listar os Produtos de uma determinada página com todas as categorias
            // @"\d+" => Regular Expression para apenas números inteiros  
            routes.MapRoute(
                //Padrão que a Url terá. Entre chaves é o parâmetro que a action receberá
                null, "Pagina{pagina}",
                new { controller = "Vitrine", action = "ListaProdutos", categoria = (string)null },
                new { pagina = @"\d+" });
            
            // Listar os Produtos de uma determinada categoria da primeira página
            routes.MapRoute(null, "{categoria}",
                new { controller = "Vitrine", action = "ListaProdutos", pagina = 1 });

            // Listar os Produtos de uma determinada categoria e página
            routes.MapRoute(null, "{categoria}/Pagina{pagina}",
                new { controller = "Vitrine", action = "ListaProdutos"},
                new { pagina = @"\d+" });

            // Rota Padrão
            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}
