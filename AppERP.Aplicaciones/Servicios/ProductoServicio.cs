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
    public class ProductoServicio : IServicioBase<Producto, Guid>
    {
        private readonly IRepositorioBase<Producto, Guid> repoProducto;

        public ProductoServicio (IRepositorioBase<Producto, Guid> _repoProducto)
        {
            repoProducto = _repoProducto;
        }
        public Producto Agregar(Producto entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("El producto  es requerido");

            var resultProducto = repoProducto.Agregar(entidad);
            return resultProducto;
        }

        public void Editar(Producto entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("El producto es requerido para editar");

            repoProducto.Editar(entidad);
            repoProducto.Guardar();
        }

        public void Eliminar(Guid entidadID)
        {
            repoProducto.Eliminar(entidadID);
            repoProducto.Guardar();
        }

        public List<Producto> Listar()
        {
            return repoProducto.Listar();
        }

        public Producto SeleccionarPorID(Guid entidadID)
        {
            return repoProducto.SeleccionarPorID(entidadID);
        }
    }
}
