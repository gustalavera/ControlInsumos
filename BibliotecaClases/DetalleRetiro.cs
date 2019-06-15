using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaClases
{
    public class DetalleRetiro
    {
        public Retiro Retiro { get; set; }
        public Insumo Insumo { get; set; }
        public int Cantidad { get; set; }

        public Proveedor proveedor { get; set; }

    }
}
