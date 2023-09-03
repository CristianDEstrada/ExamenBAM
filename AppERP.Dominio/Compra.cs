using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppERP.Dominio
{
    public class Compra
    {
        public Guid compraId {get;set;}
        public string numeroCompra { get;set;}

        public DateTime fecha { get;set;}
        public string concepto { get;set;}
        public decimal subtotal { get;set;}
        public decimal total { get;set;}

        public List<CompraDetalle> CompraDetalles { get;set;}
    }
}
