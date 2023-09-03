using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppERP.Dominio;
using System.Linq;
using AppERP.Infraestructura.Datos.Configs;
using AppERP.Infraestructura.Datos.Contexto;
using AppERP.Dominio.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AppERP.Infraestructura.Datos.Repositorios
{
    public class CompraRepositorio : IRepositorioMovimiento<Compra, Guid>
    {

        private CompraContexto db;

        public CompraRepositorio(CompraContexto _db)
        {
            db = _db;
        }
        public Compra Agregar(Compra entidad)
        {
            entidad.compraId = Guid.NewGuid();
            db.Compras.Add(entidad);
            return entidad;
        }

        public void Anular(Guid entidadID)
        {
            var compraSeleccionada = db.Compras.Where(c => c.compraId == entidadID).FirstOrDefault();
            if (compraSeleccionada == null)
                throw new NullReferenceException("Esta intentando anular una venta no existente");

            compraSeleccionada.anulado = true;

            db.Entry(compraSeleccionada).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Guardar()
        {
            db.SaveChanges();
        }

        public List<Compra> Listar()
        {
            return db.Compras.ToList();
        }

        public Compra SeleccionarPorID(Guid entidadID)
        {
            var compraSeleccionada = db.Compras.Where(c => c.compraId == entidadID).FirstOrDefault();
            return compraSeleccionada;
        }
    }
}
