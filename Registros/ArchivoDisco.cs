using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discos;
using Microsoft.SqlServer.Server;

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
                lector.setConsulta("Select Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa, E.Descripcion as EstiloMusical, T.Descripcion as Formato from DISCOS D, ESTILOS E, TIPOSEDICION T Where D.IdEstilo = E.Id and T.Id = D.IdTipoEdicion");
                lector.realizarConsulta();


                while (lector.Lector.Read())
                {
                    Disco disco = new Disco();
                    disco.Name = (string)lector.Lector["Titulo"];
                    disco.Fecha = (DateTime)lector.Lector["FechaLanzamiento"];
                    disco.UrlImagen = (string)lector.Lector["UrlImagenTapa"];
                    disco.Tracks = lector.Lector.GetInt32(2);
                    disco.Genre = new Estilo();
                    disco.Genre.Description = (string)lector.Lector["EstiloMusical"];
                    disco.Formato = new Estilo();
                    disco.Formato.Description = (string)lector.Lector["Formato"];
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

        public void agregarDisco(Disco disco)
        {
            LecturaRegistros sql = new LecturaRegistros("server=.\\SQLEXPRESS; database=DISCOS_DB; integrated security=true");
            try
            {
                string valores = "('" + disco.Name + "','" + disco.Tracks + "','" + disco.UrlImagen + "','"+disco.Genre.Id+"','"+disco.Formato.Id+"','"+disco.Fecha.ToString("d")+"')";
                string accion = "Insert into DISCOS (Titulo,CantidadCanciones, UrlImagenTapa, IdEstilo, IdTipoEdicion, FechaLanzamiento) values" + valores;
                sql.setConsulta(accion);
                sql.ejecutarAccion();
                sql.cerrarConexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
