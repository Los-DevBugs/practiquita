using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;  //Cadena de conexión

namespace CapaNegocio
{

    public class Alumno
    {
        //Cadena Conexion
        private static string cadena = ConfigurationManager.ConnectionStrings["Cadena"].ConnectionString;


        public string CodAlumno { get; set; }
        public string APaterno { get; set; }
        public string AMaterno { get; set; }
        public string Nombres { get; set; }
        public string Usuario { get; set; }
        public string CodCarrera { get; set; }

        //Implementar los metodos de la clase

        public DataTable Listar()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "select * from TAlumno";
                SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion);
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                return tabla;
            }
        }

        public bool Agregar()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "insert into TAlumno values(@CodAlumno,@APaterno,@AMaterno,@Nombres,@Usuario,@CodCarrera)";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@CodAlumno", CodAlumno);
                comando.Parameters.AddWithValue("@APaterno", APaterno);
                comando.Parameters.AddWithValue("@AMaterno", AMaterno);
                comando.Parameters.AddWithValue("@Nombres", Nombres);
                comando.Parameters.AddWithValue("@Usuario", Usuario);
                comando.Parameters.AddWithValue("@CodCarrera", CodCarrera);
                conexion.Open();
                byte i = Convert.ToByte(comando.ExecuteNonQuery());
                conexion.Close();
                if (i == 1) return true;
                else return false;
            }
        }

        public bool Eliminar()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "delete from TAlumno where CodAlumno = @CodAlumno";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@CodAlumno", CodAlumno);
                conexion.Open();
                byte i = Convert.ToByte(comando.ExecuteNonQuery());
                conexion.Close();
                if (i == 1) return true;
                else return false;
            }
        }

        public bool Actualizar()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "update TAlumno set APaterno=@APaterno, AMaterno=@AMaterno, Nombres=@Nombres, Usuario=Usuario, CodCarrera=@CodCarrera where CodAlumno=@CodAlumno";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@CodAlumno", CodAlumno);
                comando.Parameters.AddWithValue("@APaterno", APaterno);
                comando.Parameters.AddWithValue("@AMaterno", AMaterno);
                comando.Parameters.AddWithValue("@Nombres", Nombres);
                comando.Parameters.AddWithValue("@Usuario", Usuario);
                comando.Parameters.AddWithValue("@CodCarrera", CodCarrera);
                conexion.Open();
                byte i = Convert.ToByte(comando.ExecuteNonQuery());
                conexion.Close();
                if (i == 1) return true;
                else return false;
            }
        }

        public DataTable Buscar(string criterio)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "SELECT * FROM TAlumno WHERE CodAlumno = @Criterio OR Usuario LIKE '%' + @Criterio + '%'";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@Criterio", criterio);
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }
    }


}
