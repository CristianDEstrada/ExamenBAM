using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppERP.Dominio;
using AppERP.Dominio.Interfaces.Repositorios;
using AppERP.Aplicaciones.Interfaces;
namespace AppERP.Aplicaciones.Servicios
{
    public class CompraServicio : IServicioMovimiento<Compra, Guid>
    {
        IRepositorioMovimiento<Compra, Guid> repoCompra;
        IRepositorioBase<Producto, Guid> repoProducto;
        IRepositorioDetalle<CompraDetalle, Guid> repoDetalle;

        public CompraServicio
        (          
            IRepositorioMovimiento<Compra, Guid> _repoCompra,
            IRepositorioBase<Producto, Guid> _repoProducto,
            IRepositorioDetalle<CompraDetalle, Guid> _repoDetalle
        ){
            repoCompra = _repoCompra;
            repoProducto = _repoProducto;
            repoDetalle = _repoDetalle;        
        }

        public  Compra Agregar(Compra entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("La Compra es requerida");

            var compraAgregada = repoCompra.Agregar(entidad);

            entidad.CompraDetalles.ForEach(detalle =>
            {
                var productoSeleccionado = repoProducto.SeleccionarPorID(detalle.productoId);
                if (productoSeleccionado == null)
                    throw new ArgumentException("No existe el producto");

                var detalleNuevo = new CompraDetalle();
                detalleNuevo.productoId = detalle.productoId;
                detalleNuevo.costoUnitario = productoSeleccionado.costo;
                detalleNuevo.precioUnitario = productoSeleccionado.precio;
                detalleNuevo.subtotal = detalleNuevo.precioUnitario * detalleNuevo.cantidadCompra;
                detalle.ipuesto = detalleNuevo.subtotal * 15 / 100;
                detalleNuevo.total = detalleNuevo.subtotal + detalleNuevo.ipuesto;
                repoDetalle.Agregar(detalleNuevo);

                productoSeleccionado.cantidadEnStock -= detalleNuevo.cantidadCompra;
                repoProducto.Editar(productoSeleccionado);

                entidad.subtotal += detalleNuevo.subtotal;
               
                //entidad. impuesto
                entidad.total += detalleNuevo.total;

            });

            repoCompra.Guardar();
            return entidad;

        }

        public void Anular(Guid entidadID)
        {
            repoCompra.Anular(entidadID);
            repoCompra.Guardar();

        }

        public List<Compra> Listar()
        {
           return repoCompra.Listar();
        }

        public Compra SeleccionarPorID(Guid entidadID)
        {
           return repoCompra.SeleccionarPorID(entidadID) ;
        }
    }
}
