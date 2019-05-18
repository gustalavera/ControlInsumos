using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaClases
{
    public class Marca
    {
        public string Cod_Marca { get; set; }
        public string Descripcion { get; set; }
        public static List<Marca> listaMarca = new List<Marca>();

        public static void AgregarMarca(Marca m)
        {
            listaMarca.Add(m);
        }
        public static void EliminarMarca(Marca m)
        {
            listaMarca.Remove(m);
        }
        public static List<Marca> ObtenerMarca()
        {
            return listaMarca;
        }
        public override string ToString()
        {
            return Descripcion;

        }
    }

}
