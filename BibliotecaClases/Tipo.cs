using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaClases
{
    public class Tipo
    {
        public string Cod_Tipo { get; set; }
        public string Descripcion { get; set; }

        public static List<Tipo> listaTipo = new List<Tipo>();

        public static void AgregarTipo(Tipo t)
        {
            listaTipo.Add(t);
        }
        public static void EliminarTipo(Tipo t)
        {
            listaTipo.Remove(t);
        }
        public static List<Tipo> ObtenerTipo()
        {
            return listaTipo;
        }
        public override string ToString()
        {
            return Descripcion;

        }
    }

}
