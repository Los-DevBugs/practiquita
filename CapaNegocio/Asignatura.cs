using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Asignatura
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["Cadena"].ConnectionString;

        // mapear las columnas de la tabla en columnas de la clase
        public string CodAsignatura { get; set; }

        public string NombreAsignatura { get; set; }

        public string CodRequisito { get; set; }

        //Implementar los metodos de la clase
        public DataTable Listar()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "select * from TAsignatura";
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
                string consulta = "insert into TAsignatura values(@CodAsignatura,@NombreAsignatura,@CodRequisito)";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@CodAsignatura", CodAsignatura);
                comando.Parameters.AddWithValue("@NombreAsignatura", NombreAsignatura);
                comando.Parameters.AddWithValue("@CodRequisito", CodRequisito);
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
                string consulta = "delete from TAsignatura where CodAsignatura = @CodAsignatura";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@CodAsignatura", CodAsignatura);
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
                string consulta = "update TAsignatura set Asignatura=@NombreAsignatura, CodRequisito=@CodRequisito where CodAsignatura=@CodAsignatura";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@CodAsignatura", CodAsignatura);
                comando.Parameters.AddWithValue("@NombreAsignatura", NombreAsignatura);
                comando.Parameters.AddWithValue("@CodRequisito", CodRequisito);
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
                string consulta = "SELECT * FROM TAsignatura WHERE CodAsignatura = @Criterio OR Asignatura LIKE '%' + @Criterio + '%'";
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
