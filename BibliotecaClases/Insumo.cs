using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaClases;

namespace BibliotecaClases
{
    public class Insumo
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public Marca Marca { get; set; }
        public Tipo Tipo { get; set; }
        public Proveedor Proveedor { get; set; }
        public int Cantidad_Disponible { get; set; }
        public int Cantidad_Minima { get; set; }

        public static List<Insumo> listaInsumos = new List<Insumo>();
        public static void AgregarInsumo(Insumo i)
        {
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
            {
                con.Open();
                string textoCmd = @"insert into Insumo (Descripcion,Marca,Tipo,Proveedor,Cantidad_Disponible,Cantidad_Minima) VALUES (@Descripcion,@Marca,@Tipo,@Proveedor,@Cantidad_Disponible,@Cantidad_Minima)";

                SqlCommand cmd = new SqlCommand(textoCmd, con);
                cmd = i.ObtenerParametros(cmd, false);

                cmd.ExecuteNonQuery();
               

            }
        }
        public static void EliminarInsumo(Insumo i)
        {
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
            {
                con.Open();
                string textoCmd = @"delete from Insumo where Id = @Id";

                SqlCommand cmd = new SqlCommand(textoCmd, con);
                cmd = i.ObtenerParametroId(cmd);

                cmd.ExecuteNonQuery();
            }
        }

        private SqlCommand ObtenerParametros(SqlCommand cmd, Boolean id = false)
        {
           
            SqlParameter i1 = new SqlParameter("@Descripcion", this.Descripcion);
            SqlParameter i2 = new SqlParameter("@Marca", this.Marca);
            SqlParameter i3 = new SqlParameter("@Tipo", this.Tipo);
            SqlParameter i4 = new SqlParameter("@Proveedor", this.Proveedor);
            SqlParameter i5 = new SqlParameter("@Cantidad_Disponible", this.Cantidad_Disponible);
            SqlParameter i6 = new SqlParameter("@Cantidad_Minima", this.Cantidad_Minima);
            i1.SqlDbType = SqlDbType.VarChar;
            i2.SqlDbType = SqlDbType.Int;
            i3.SqlDbType = SqlDbType.Int;
            i4.SqlDbType = SqlDbType.Int;
            i5.SqlDbType = SqlDbType.Int;
            i6.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(i1);
            cmd.Parameters.Add(i2);
            cmd.Parameters.Add(i3);
            cmd.Parameters.Add(i4);
            cmd.Parameters.Add(i5);
            cmd.Parameters.Add(i6);

            if (id == true)
            {
                cmd = ObtenerParametroId(cmd);
            }

            return cmd;
        }
    
        public static Insumo ObtenerInsumo(int id)
        {
            Insumo insumo = null;

            if (listaInsumos.Count == 0) Insumo.ObtenerInsumos();

            foreach (Insumo i in listaInsumos)
            {
                if (i.Id == id)
                {
                    insumo = i;
                    break;
                }

            }
            return insumo;




        }
        public static void ModificarInsumo(int index, Insumo i)
        {

            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
            {
                con.Open();
                string textoCmd = @"UPDATE Insumo SET Descripcion=@Descripcion,Marca=@Marca,Tipo=@Tipo,Proveedor=@Proveedor,Cantidad_Disponible=@Cantidad_Disponible,Cantidad_Minima = @Cantidad_Minima where Id = @Id";
                SqlCommand cmd = new SqlCommand(textoCmd, con);

                SqlParameter i1 = new SqlParameter("@Descripcion", i.Descripcion);
                SqlParameter i2 = new SqlParameter("@Marca", i.Marca);
                SqlParameter i3 = new SqlParameter("@Tipo", i.Tipo);
                SqlParameter i4 = new SqlParameter("@Proveedor", i.Proveedor);
                SqlParameter i5 = new SqlParameter("@Cantidad_Disponible", i.Cantidad_Disponible);
                SqlParameter i6 = new SqlParameter("@Cantidad_Minima", i.Cantidad_Minima);
                SqlParameter i7 = new SqlParameter("@Id", i.Id);
                i1.SqlDbType = SqlDbType.VarChar;
                i2.SqlDbType = SqlDbType.Int;
                i3.SqlDbType = SqlDbType.Int;
                i4.SqlDbType = SqlDbType.Int;
                i5.SqlDbType = SqlDbType.Int;
                i6.SqlDbType = SqlDbType.Int;
                i7.SqlDbType = SqlDbType.Int;
                cmd.Parameters.Add(i1);
                cmd.Parameters.Add(i2);
                cmd.Parameters.Add(i3);
                cmd.Parameters.Add(i4);
                cmd.Parameters.Add(i5);
                cmd.Parameters.Add(i6);
                cmd.Parameters.Add(i7);

                cmd.ExecuteNonQuery();
            }
        }

        public static List<Insumo> ObtenerInsumos()
        {

            Insumo insumo;
            listaInsumos.Clear();

            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
            {
                con.Open();
                string textoCmd = "Select * from Insumo";

                SqlCommand cmd = new SqlCommand(textoCmd, con);

                SqlDataReader elLectorDeDatos = cmd.ExecuteReader();

                while (elLectorDeDatos.Read())
                {

                    insumo = new Insumo();
                    insumo.Id = elLectorDeDatos.GetInt32(0);
                    insumo.Descripcion = elLectorDeDatos.GetString(1);
                    insumo.Marca = Marca.ObtenerMarca(elLectorDeDatos.GetInt32(2));
                    insumo.Tipo = Tipo.ObtenerTipo(elLectorDeDatos.GetInt32(3));
                    insumo.Proveedor = Proveedor.ObtenerProveedor(elLectorDeDatos.GetInt32(4));
                    insumo.Cantidad_Disponible = elLectorDeDatos.GetInt32(5);
                    insumo.Cantidad_Minima = elLectorDeDatos.GetInt32(6);






                    listaInsumos.Add(insumo);
                }
            }
            return listaInsumos;
        }
       
        public override string ToString()
        {
            return Descripcion;

        }
        private SqlCommand ObtenerParametroId(SqlCommand cmd)
        {
            SqlParameter i7 = new SqlParameter("@Id", this.Id);
            i7.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(i7);

            return cmd;
        }
    }
}
