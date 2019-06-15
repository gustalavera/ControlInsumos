using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BibliotecaClases
{
    public enum Dias {
        Lunes,
        Martes,
        Miércoles,
        Jueves,
        Viernes,
        Sábado
    }
    public class Proveedor
    {
        
        public int Id { get; set; }
        public string Razon_Social { get; set; }
        public string RUC { get; set; }
        public string Direccion { get; set; }
        public string Contacto { get; set; }
        public string Email { get; set; }
        public List<string> Dias_Visita { get; set; }
    

        public static List<Proveedor> listaProveedores = new List<Proveedor>();

        public static void AgregarProveedor(Proveedor p)
        {
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
            {
                con.Open();

                string textoCmd = @"insert into Proveedor (Razon_Social, RUC, Direccion, Contacto, Email, Dias_Visita) VALUES (@Razon_Social,@RUC, @Direccion, @Contacto, @Email, @Dias_Visita)";

                SqlCommand cmd = new SqlCommand(textoCmd, con);
                cmd = p.ObtenerParametros(cmd, false);

                cmd.ExecuteNonQuery();


            }
        }
        public static List<Proveedor> ObtenerProveedores()
        {
            
            Proveedor proveedor;
            listaProveedores.Clear();

            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
            {
                con.Open();
                string textoCmd = "Select * from Proveedor";

                SqlCommand cmd = new SqlCommand(textoCmd, con);

                SqlDataReader elLectorDeDatos = cmd.ExecuteReader();

                while (elLectorDeDatos.Read())
                {
                    proveedor = new Proveedor();
                    proveedor.Id = elLectorDeDatos.GetInt32(0);
                    proveedor.Razon_Social = elLectorDeDatos.GetString(1);
                    proveedor.RUC = elLectorDeDatos.GetString(2);
                    proveedor.Direccion = elLectorDeDatos.GetString(3);
                    proveedor.Contacto = elLectorDeDatos.GetString(4);
                    proveedor.Email = elLectorDeDatos.GetString(5);
                    proveedor.Dias_Visita = ObtenerListaDiasVisita(elLectorDeDatos.GetString(6));
                    listaProveedores.Add(proveedor);
                }
            }
            return listaProveedores;
        }
        public static void EliminarProveedor(Proveedor p)
        {
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
            {
                con.Open();
                string textoCmd = @"delete from Proveedor where Id = @Id";

                SqlCommand cmd = new SqlCommand(textoCmd, con);
                SqlParameter p7 = new SqlParameter("@Id", p.Id);
                p7.SqlDbType = SqlDbType.Int;
                cmd.Parameters.Add(p7);

                cmd.ExecuteNonQuery();
            }
        }
        public static void EditarProveedor(int index, Proveedor p)
        {
         
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
            {
                con.Open();
                string textoCmd = @"UPDATE Proveedor SET Razon_Social = @Razon_Social,  RUC=@RUC, Direccion=@Direccion, Contacto=@Contacto, Email=@Email, Dias_Visita=@Dias_Visita where Id = @Id";
                SqlCommand cmd = new SqlCommand(textoCmd, con);
                cmd = p.ObtenerParametros(cmd, true);

                cmd.ExecuteNonQuery();

            }
        }

       
        private static List<string> ObtenerListaDiasVisita(string dias)
        {
            return dias.Split(',').ToList();
        }
        private string ObtenerStringDiasEntrega()
        {
            return string.Join(",", this.Dias_Visita);

        }
       


        private SqlCommand ObtenerParametros(SqlCommand cmd, Boolean id = false)
        {

            SqlParameter p1 = new SqlParameter("@Razon_Social", this.Razon_Social);
            SqlParameter p2 = new SqlParameter("@RUC", this.RUC);
            SqlParameter p3 = new SqlParameter("@Direccion", this.Direccion);
            SqlParameter p4 = new SqlParameter("@Contacto", this.Contacto);
            SqlParameter p5 = new SqlParameter("@Email", this.Email);
            SqlParameter p6 = new SqlParameter("@Dias_Visita", this.ObtenerStringDiasEntrega());
            p1.SqlDbType = SqlDbType.VarChar;
            p2.SqlDbType = SqlDbType.VarChar;
            p3.SqlDbType = SqlDbType.VarChar;
            p4.SqlDbType = SqlDbType.VarChar;
            p5.SqlDbType = SqlDbType.VarChar;
            p6.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);
            cmd.Parameters.Add(p5);
            cmd.Parameters.Add(p6);

            if (id == true)
            {
                cmd = ObtenerParametroId(cmd);
            }

            return cmd;
        }
        public static Proveedor ObtenerProveedor(int id)
        {
            Proveedor proveedor = null;

            if (listaProveedores.Count == 0) Proveedor.ObtenerProveedores();

            foreach (Proveedor p in listaProveedores)
            {
                if (p.Id == id)
                {
                    proveedor = p;
                    break;
                }

            }
            return proveedor;




        }

        public SqlCommand ObtenerParametroId(SqlCommand cmd)
        {
            SqlParameter p7 = new SqlParameter("@id", this.Id);
            p7.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(p7);

            return cmd;
        }
        public override string ToString()
        {
            return this.Razon_Social;
        }


    }
    
}

