using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaClases
{
    public class Insumo
    {
        public string Cod_Insumo { get; set; }
        public string Descripcion { get; set; }
        public Marca Marca { get; set; }
        public Tipo Tipo { get; set; }
        public Proveedor Proveedor { get; set; }
        public string Cantidad_Disponible { get; set; }
        public string Cantidad_Minima { get; set; }

        public static List<Insumo> listaInsumos = new List<Insumo>();
        public static void AgregarInsumos(Insumo i)
        {
            listaInsumos.Add(i);
        }
        public static void EliminarInsumos(Insumo i)
        {
            listaInsumos.Remove(i);
        }
        public static List<Insumo> ObtenerInsumos()
        {
            return listaInsumos;
        }
        public static List<Insumo> ObtenerInsumo()
        {
            return listaInsumos;
        }
        public override string ToString()
        {
            return "Descripción: " + Descripcion + ";" + "Marca: " + Marca + ";" + "Tipo: " + Tipo + ";" + "Proveedor: " + Proveedor + ";" + "Cantidad Disponible: " + Cantidad_Disponible + ";" + "Cantidad Mínima: " + Cantidad_Minima;

        }
    }
}
