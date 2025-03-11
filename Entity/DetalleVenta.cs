using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class DetalleVenta
    {
        public int IdDetalleVente { get; set; }
        public int Venta { get; set; }
        public Producto oProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
        public int IdTransaccion { get; set; }        
    }
}
