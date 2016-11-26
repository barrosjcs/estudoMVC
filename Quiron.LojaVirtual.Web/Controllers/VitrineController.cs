using Quiron.LojaVirtual.Dominio.Entidades;
using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Web.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class VitrineController : Controller
    {
        #region Variaveis e Propriedades

        private readonly ProdutosRepositorio repositorio = new ProdutosRepositorio();
        private readonly int ProdutosPorPagina = 12;

        #endregion

        //public ViewResult ListaProdutos(string categoria, int pagina = 1)
        //{
        //    // ActionResult Subtypes: ViewResult - Renders a specified view to the response stream
        //    ProdutosViewModel model = new ProdutosViewModel();

        //    model.Produtos = repositorio.Produtos.Where(p => categoria == null || p.Categoria.Trim() == categoria).
        //        OrderBy(p => p.Descricao).Skip((pagina - 1) * ProdutosPorPagina).Take(ProdutosPorPagina);

        //    model.Paginacao = new Paginacao();
        //    model.Paginacao.PaginaAtual = pagina;
        //    model.Paginacao.ItensPorPagina = ProdutosPorPagina;

        //    if(categoria == null)
        //        model.Paginacao.ItensTotal = repositorio.Produtos.Count();
        //    else
        //        model.Paginacao.ItensTotal = repositorio.Produtos.Count(p => p.Categoria.Trim() == categoria);

        //    model.CategoriaAtual = categoria;

        //    return View(model);
        //}

        public ViewResult ListaProdutos(string categoria)
        {
            // ActionResult Subtypes: ViewResult - Renders a specified view to the response stream
            ProdutosViewModel model = new ProdutosViewModel();
            Random random = new Random();

            if(categoria != null)
            {
                model.Produtos = repositorio.Produtos.
                    Where(p => p.Categoria.Trim() == categoria).
                    OrderBy(x => random.Next()).ToList();
            }
            else
            {
                model.Produtos = repositorio.Produtos.
                    OrderBy(x => random.Next()).
                    Take(ProdutosPorPagina).ToList();
            }

            return View(model);
        }

        public FileContentResult ObterImagem(int produtoId)
        {
            Produto prod = repositorio.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);

            if (prod != null)
            {
                return File(prod.Imagem, prod.ImagemMimeType);
            }

            return null;
        }

        [Route("DetalhesProduto/{id}/{produto}")]
        public ViewResult Detalhes(int id)
        {
            Produto produto = repositorio.ObterProduto(id);
            return View(produto);
        }

    }
}