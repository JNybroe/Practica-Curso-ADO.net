using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Discos;

namespace Registros
{
    public class LecturaRegistros
    {
        private SqlConnection conexion;
        private SqlCommand cmd;
        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public LecturaRegistros(string ruta="")
        {
            conexion = new SqlConnection(ruta);
            cmd = new SqlCommand();
        }

        public void setConsulta (string consulta)
        {
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = consulta;
        }

        public void realizarConsulta()
        {
            cmd.Connection = conexion;
            try
            {
                conexion.Open();
                lector = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void cerrarConexion()
        {
            if(lector != null)
            {
                lector.Close();
                conexion.Close();
            }
        }

        public void setearParametro(string parametro, object valor) 
        {
            cmd.Parameters.AddWithValue(parametro, valor);
        }

        public void ejecutarAccion()
        {
            cmd.Connection = conexion;
            try
            {
                conexion.Open ();
                cmd.ExecuteNonQuery ();

            }
            catch(Exception ex)
            {
                throw ex;
            }
          
        }

    }
}
