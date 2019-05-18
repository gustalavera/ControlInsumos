using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaClases
{
    public class Proveedor
    {
        public enum Dias { Lunes, Martes, Miércoles, Jueves, Viernes, Sábado}
        public string Cod_Proveedor { get; set; }
        public string RazonSocial { get; set; }
        public string RUC { get; set; }
        public string Direccion { get; set; }
        public string Contacto { get; set; }
        public string Email { get; set; }
        public Dias Dias_Visita { get; set; }

        public static List<Proveedor> listaProveedores = new List<Proveedor>();
        public static void AgregarProveedor(Proveedor p)
        {
            listaProveedores.Add(p);
        }
        public static void EliminarProveedor(Proveedor p)
        {
            listaProveedores.Remove(p);
        }
        public static List<Proveedor> ObtenerProveedores()
        {
            return listaProveedores;
        }
        public static List<Proveedor> ObtenerProveedor()
        {
            return listaProveedores;
        }
        public override string ToString()
        {
          return "Razon Social: " + RazonSocial + ";" + "RUC: " + RUC + ";" + "Direccion: " + Direccion + ";" + "Contacto: " + Contacto + ";" + "Email: " + Email;
           
        }
    }

}
