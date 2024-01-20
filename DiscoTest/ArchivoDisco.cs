using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DiscoTest
{
    internal class ArchivoDisco
    {
        public List<Disco> Listar()
        {
            List<Disco> lista = new List<Disco>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=DISCOS_DB; integrated security=true";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Select Titulo, CantidadCanciones, UrlImagenTapa, Descripcion as EstiloMusical from DISCOS D, ESTILOS E Where D.IdEstilo = E.Id";
                cmd.Connection = conexion;

                conexion.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Disco disco = new Disco();
                    disco.Name = (string)dr["Titulo"];
                    disco.UrlImagen = (string)dr["UrlImagenTapa"];
                    disco.Tracks = dr.GetInt32(1);
                    disco.Genre = new Estilo();
                    disco.Genre.Description = (string)dr["EstiloMusical"];
                    lista.Add(disco);
                }
                return lista;
            }catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
