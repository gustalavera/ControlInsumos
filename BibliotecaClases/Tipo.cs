using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaClases
{
    public class Tipo
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public static List<Tipo> listaTipos = new List<Tipo>();

        public static void AgregarTipo(Tipo t)
        {
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
            {
                con.Open();
                string textoCmd = @"insert into Tipo (Descripcion) VALUES (@Descripcion)";
                SqlCommand cmd = new SqlCommand(textoCmd, con);
                SqlParameter t1 = new SqlParameter("@Descripcion", t.Descripcion);
                t1.SqlDbType = SqlDbType.VarChar;
                cmd.Parameters.Add(t1);


                cmd.ExecuteNonQuery();

            }
        }
        public static void EliminarTipo(Tipo t)
        {
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
            {
                con.Open();
                string textoCmd = @"delete from Tipo where Id = @Id";

                SqlCommand cmd = new SqlCommand(textoCmd, con);
                cmd = t.ObtenerParametroId(cmd);

                cmd.ExecuteNonQuery();
            }
        }
        public static void ModificarTipo(int index, Tipo t)
        {

            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
            {
                con.Open();
                string textoCmd = @"UPDATE Tipo SET Descripcion = @Descripcion where Id = @Id";
                SqlCommand cmd = new SqlCommand(textoCmd, con);

                SqlParameter t1 = new SqlParameter("@Descripcion", t.Descripcion);
                SqlParameter t2 = new SqlParameter("@Id", t.Id);

                t1.SqlDbType = SqlDbType.VarChar;
                t2.SqlDbType = SqlDbType.Int;
                cmd.Parameters.Add(t1);
                cmd.Parameters.Add(t2);


                cmd.ExecuteNonQuery();
            }
        }
        public static List<Tipo> ObtenerTipos()
        {

            Tipo tipo;
            listaTipos.Clear();

            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
            {
                con.Open();
                string textoCmd = "Select * from Tipo";

                SqlCommand cmd = new SqlCommand(textoCmd, con);

                SqlDataReader elLectorDeDatos = cmd.ExecuteReader();

                while (elLectorDeDatos.Read())
                {

                    tipo = new Tipo();
                    tipo.Id = elLectorDeDatos.GetInt32(0);
                    tipo.Descripcion = elLectorDeDatos.GetString(1);



                    listaTipos.Add(tipo);
                }
            }
            return listaTipos;
        }
        public static Tipo ObtenerTipo(int id)
        {
            Tipo tipo = null;

            if (listaTipos.Count == 0) Tipo.ObtenerTipos();

            foreach (Tipo t in listaTipos)
            {
                if (t.Id == id)
                {
                    tipo = t;
                    break;
                }

            }
            return tipo;
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
