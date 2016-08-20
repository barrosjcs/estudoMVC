﻿using Quiron.LojaVirtual.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class ProdutosController : Controller
    {
        private ProdutosRepositorio repositorio = new ProdutosRepositorio();

        // GET: Produtos
        public ActionResult Index()
        {
            var produtos = repositorio.Produtos.Take(10);

            return View(produtos);
        }
    }
}