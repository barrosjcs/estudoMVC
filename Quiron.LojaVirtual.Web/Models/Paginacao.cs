using System;

namespace Quiron.LojaVirtual.Web.Models
{
    public class Paginacao
    {
        public int ItensTotal { get; set; }
        public int ItensPorPagina { get; set; }
        public int PaginaAtual { get; set; }
        public int TotalPaginas
        {
            get
            {
                return Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(ItensTotal / ItensPorPagina)));
            }
        }
    }
}