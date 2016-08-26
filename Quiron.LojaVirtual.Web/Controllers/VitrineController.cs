using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class VitrineController : Controller
    {
        #region Variaveis e Propriedades

        private ProdutosRepositorio repositorio = new ProdutosRepositorio();
        private int ProdutosPorPagina = 8;

        #endregion

        /// <summary>
        /// Lista os Produtos
        /// </summary>
        /// <param name="pagina">Número da página</param>
        /// <returns></returns>
        public ViewResult ListaProdutos(string categoria, int pagina = 1)
        {
            // ActionResult Subtypes: ViewResult - Renders a specified view to the response stream
            ProdutosViewModel model = new ProdutosViewModel();

            model.Produtos = repositorio.Produtos.Where(p => categoria == null || p.Categoria.Trim() == categoria).
                OrderBy(p => p.Descricao).Skip((pagina - 1) * ProdutosPorPagina).Take(ProdutosPorPagina);

            model.Paginacao = new Paginacao();
            model.Paginacao.PaginaAtual = pagina;
            model.Paginacao.ItensPorPagina = ProdutosPorPagina;

            if(categoria == null)
                model.Paginacao.ItensTotal = repositorio.Produtos.Count();
            else
                model.Paginacao.ItensTotal = repositorio.Produtos.Where(p => p.Categoria.Trim() == categoria).Count();

            model.CategoriaAtual = categoria;

            return View(model);
        }
    }
}