using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaClases
{
    public class Retiro
    {
        public string Cod_Retiro { get; set; }
        public string Fecha { get; set; }
        public Funcionario Retirado_por { get; set; }
        public Usuario Entregado_por { get; set; }
        public Funcionario Beneficiario { get; set; }
    }
}
