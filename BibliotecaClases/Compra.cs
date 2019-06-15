using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaClases
{
    public class Compra
    {
        public string Id_Compra { get; set; }
        public DateTime Fecha { get; set; }
        public Proveedor Proveedor { get; set; }
        public string Nro_OrdenPago { get; set; }
        public string Nro_Factura { get; set; }
        public string Total { get; set; }

    }
}
