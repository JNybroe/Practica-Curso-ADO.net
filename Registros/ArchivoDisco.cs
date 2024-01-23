using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Discos;

namespace Registros
{
    public class ArchivoDisco
    {
        public List<Disco> Listar()
        {
            List<Disco> lista = new List<Disco>();
            LecturaRegistros lector = new LecturaRegistros("server=.\\SQLEXPRESS; database=DISCOS_DB; integrated security=true");

            try
            {
                lector.setConsulta("Select Titulo, CantidadCanciones, UrlImagenTapa, Descripcion as EstiloMusical from DISCOS D, ESTILOS E Where D.IdEstilo = E.Id");
                lector.realizarConsulta();


                while (lector.Lector.Read())
                {
                    Disco disco = new Disco();
                    disco.Name = (string)lector.Lector["Titulo"];
                    disco.UrlImagen = (string)lector.Lector["UrlImagenTapa"];
                    disco.Tracks = lector.Lector.GetInt32(1);
                    disco.Genre = new Estilo();
                    disco.Genre.Description = (string)lector.Lector["EstiloMusical"];
                    lista.Add(disco);
                }

                return lista;
            }catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lector.cerrarConexion();
            }

        }
    }
}
