using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using AppERP.Infraestructura.Datos.Configs;
using AppERP.Infraestructura.Datos.Contexto;
using AppERP.Dominio.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore.Diagnostics;
using AppERP.Dominio.Interfaces;
using AppERP.Dominio;

namespace AppERP.Infraestructura.Datos.Repositorios
{
    public class CompraDetalleRepositorio : IRepositorioDetalle<CompraDetalle, Guid>
    {
        private CompraContexto db;

        public CompraDetalleRepositorio(CompraContexto _db)
        {
            db = _db;
        }

        public CompraDetalle Agregar(CompraDetalle entidad)
        {
            db.ComprasDetalle.Add(entidad);
            return entidad;
        }

        public void Guardar()
        {
            db.SaveChanges();
        }
    }
}
