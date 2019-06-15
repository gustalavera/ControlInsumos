using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaClases
{
    public class Retiro
    {
        public int Id_Retiro { get; set; }
        public DateTime Fecha { get; set; }
        public Funcionario Retirado_por { get; set; }
        public Usuario Entregado_por { get; set; }
        public Funcionario Beneficiario { get; set; }

        public Departamento Departamento { get; set; }
    }
}
