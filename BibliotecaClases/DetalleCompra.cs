using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaClases
{
    public class DetalleCompra
    {
        public Compra Compra { get; set; }
        public Insumo Insumo { get; set; }
        public string Cantidad { get; set; }
        public string Subtotal { get; set; }

    }
}
