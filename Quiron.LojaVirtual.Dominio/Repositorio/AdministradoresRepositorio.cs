using Quiron.LojaVirtual.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.Dominio.Repositorio
{
    public class AdministradoresRepositorio
    {
        private readonly EfDbContext context = new EfDbContext();

        public Administrador ObterAdministrador(Administrador administrador)
        {
            return context.Administradores.FirstOrDefault(a => a.Login == administrador.Login);
        }
    }
}
