using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppERP.Dominio
{
    public class CompraDetalle
    {
        public Guid productoId {  get; set; }
        public Guid CompraId { get; set; }
        public decimal costoUnitario { get; set; }
        public decimal precioUnitario { get; set; }
        public decimal cantidadCompra { get; set; }
        public decimal subtotal {  get; set; }
        public decimal ipuesto { get; set; }
        public decimal total { get; set; }

        public Producto Producto { get; set; }
        public Compra Compra { get; set; }


    }
}
