using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppERP.Dominio;
using System.Linq;
using AppERP.Infraestructura.Datos.Configs;
using AppERP.Infraestructura.Datos.Contexto;
using AppERP.Dominio.Interfaces.Repositorios;

namespace AppERP.Infraestructura.Datos.Repositorios
{
    public class ProductoRepositorio : IRepositorioBase<Producto, Guid>
    {
        private CompraContexto db;

        public ProductoRepositorio(CompraContexto _db)
        {
            db = _db;
        }
        public Producto Agregar(Producto entidad)
        {
            entidad.productoId = Guid.NewGuid();
            db.Productos.Add(entidad);
            return entidad;
        }

        public void Editar(Producto entidad)
        {
            var productoSeleccionado = db.Productos.Where(c => c.productoId == entidad.productoId).FirstOrDefault();
            if (productoSeleccionado != null) {
                productoSeleccionado.nombre = entidad.nombre;
                productoSeleccionado.descripcion = entidad.descripcion;
                productoSeleccionado.costo = entidad.costo;
                productoSeleccionado.precio = entidad.precio;
                productoSeleccionado.cantidadEnStock = entidad.cantidadEnStock;

                db.Entry(productoSeleccionado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            }
        }

        public void Eliminar(Guid entidadID)
        {
            var productoSeleccionado = db.Productos.Where(c => c.productoId == entidadID).FirstOrDefault();
            if (productoSeleccionado != null)
            {
                db.Productos.Remove(productoSeleccionado);

            }
        }

        public void Guardar()
        {
            db.SaveChanges();
        }

        public List<Producto> Listar()
        {
            return db.Productos.ToList();
        }

        public Producto SeleccionarPorID(Guid entidadID)
        {
            var productoSeleccionado = db.Productos.Where(c => c.productoId == entidadID).FirstOrDefault();
            return productoSeleccionado;
               

            
        }
    }
}
