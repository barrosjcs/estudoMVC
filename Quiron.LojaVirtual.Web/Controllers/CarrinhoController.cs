using Quiron.LojaVirtual.Dominio.Entidades;
using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Web.Models;
using System.Linq;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class CarrinhoController : Controller
    {
        private ProdutosRepositorio repositorio = new ProdutosRepositorio();

        private Carrinho CarrinhoAtual
        {
            get
            {
                Carrinho carrinho = (Carrinho)Session["Carrinho"];

                if (carrinho == null)
                {
                    carrinho = new Carrinho();
                    Session["Carrinho"] = carrinho;
                }

                return carrinho;
            }
            set
            {
                Session["Carrinho"] = value;
            }
        }
        // GET: Carrinho
        public RedirectToRouteResult Adicionar(int produtoId, string returnUrl)
        {
            Produto produto = repositorio.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);

            if(produto != null)
                CarrinhoAtual.AdicionarItem(produto, 1);

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult Remover(int produtoId, string returnUrl)
        {
            Produto produto = repositorio.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);

            if(produto != null)
                CarrinhoAtual.RemoverItem(produto);

            return RedirectToAction("Index", new { returnUrl });
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CarrinhoViewModel
            {
                Carrinho = CarrinhoAtual,
                ReturnUrl = returnUrl
            });
        }

        public PartialViewResult Resumo()
        {
            Carrinho carrinho = CarrinhoAtual;
            return PartialView(carrinho);
        }

        public ViewResult FecharPedido()
        {
            return View(new Pedido());
        }
    }
}