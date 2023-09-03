using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppERP.Dominio
{
    public class Producto
    {
        public Guid  productoId { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public decimal costo { get; set; }
        public decimal precio { get; set; }
        public decimal cantidadEnStock { get;  set; }
        //public Guid VehiculoId { get; set; }
        public List<CompraDetalle> CompraDetalles { get; set; }
    }
}
