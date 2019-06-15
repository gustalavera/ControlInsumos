using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaClases
{
    public class Marca
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public static List<Marca> listaMarcas = new List<Marca>();

        public static void AgregarMarca(Marca m)
        {
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
            {
                con.Open();
                string textoCmd = @"insert into Marca (Descripcion) VALUES (@Descripcion)";
                SqlCommand cmd = new SqlCommand(textoCmd, con);
                SqlParameter m1 = new SqlParameter("@Descripcion", m.Descripcion);
                m1.SqlDbType = SqlDbType.VarChar;
                cmd.Parameters.Add(m1);
              

                cmd.ExecuteNonQuery();

            }
        }

       
        public static void EliminarMarca(Marca m)
        {
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
            {
                con.Open();
                string textoCmd = @"delete from Marca where Id = @Id";

                SqlCommand cmd = new SqlCommand(textoCmd, con);
                cmd = m.ObtenerParametroId(cmd);

                cmd.ExecuteNonQuery();
            }
        }
       
     

        public static void ModificarMarca(int index, Marca m)
        {

            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
            {
                con.Open();
                string textoCmd = @"UPDATE Marca SET Descripcion = @Descripcion where Id = @Id";
                SqlCommand cmd = new SqlCommand(textoCmd, con);

                SqlParameter m1 = new SqlParameter("@Descripcion",m.Descripcion);
                SqlParameter m2 = new SqlParameter("@Id", m.Id);

                m1.SqlDbType = SqlDbType.VarChar;
                m2.SqlDbType = SqlDbType.Int;
                cmd.Parameters.Add(m1);
                cmd.Parameters.Add(m2);


                cmd.ExecuteNonQuery();
            }
        }

        public static List<Marca> ObtenerMarcas()
        {

            Marca marca;
            listaMarcas.Clear();

            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
            {
                con.Open();
                string textoCmd = "Select * from Marca";

                SqlCommand cmd = new SqlCommand(textoCmd, con);

                SqlDataReader elLectorDeDatos = cmd.ExecuteReader();

                while (elLectorDeDatos.Read())
                {
                   
                    marca = new Marca();
                    marca.Id = elLectorDeDatos.GetInt32(0);
                    marca.Descripcion = elLectorDeDatos.GetString(1);
                  


                    listaMarcas.Add(marca);
                }
            }
            return listaMarcas;
        }
        public static Marca ObtenerMarca(int id)
        {
            Marca marca = null;

            if (listaMarcas.Count == 0) Marca.ObtenerMarcas();

            foreach (Marca m in listaMarcas)
            {
                if (m.Id == id)
                {
                    marca = m;
                    break;
                }

            }
            return marca;

          


        }
        private SqlCommand ObtenerParametroId(SqlCommand cmd)
        {
            SqlParameter p2 = new SqlParameter("@Id", this.Id);
            p2.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(p2);

            return cmd;
        }
        public override string ToString()
        {
            return Descripcion;

        }
    }

}
