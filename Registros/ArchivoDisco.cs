﻿using System;
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
                lector.setConsulta("Select D.Id,Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa, E.Descripcion as EstiloMusical,E.Id as IdEstilo, T.Descripcion as Formato, T.Id as IdFormato from DISCOS D, ESTILOS E, TIPOSEDICION T Where D.IdEstilo = E.Id and T.Id = D.IdTipoEdicion");
                lector.realizarConsulta();


                while (lector.Lector.Read())
                {
                    Disco disco = new Disco();
                    disco.ID = (int)lector.Lector["Id"];
                    disco.Name = (string)lector.Lector["Titulo"];
                    disco.Fecha = (DateTime)lector.Lector["FechaLanzamiento"];
                    disco.UrlImagen = (string)lector.Lector["UrlImagenTapa"];
                    disco.Tracks = (int)lector.Lector["CantidadCanciones"];
                    disco.Genre = new Estilo();
                    disco.Genre.Id = (int)lector.Lector["IdEstilo"];
                    disco.Genre.Description = (string)lector.Lector["EstiloMusical"];
                    disco.Formato = new Estilo();
                    disco.Formato.Id = (int)lector.Lector["IdFormato"];
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
            LecturaRegistros lector = new LecturaRegistros("server=.\\SQLEXPRESS; database=DISCOS_DB; integrated security=true");
            try
            {
               
                lector.setearParametro("@Titulo", disco.Name);
                lector.setearParametro("@CantidadCanciones", disco.Tracks);
                lector.setearParametro("@UrlImagenTapa", disco.UrlImagen);
                lector.setearParametro("@IdEstilo", disco.Genre.Id);
                lector.setearParametro("@IdTipoEdicion", disco.Formato.Id);
                lector.setearParametro("@FechaLanzamiento", disco.Fecha.ToString("d"));
                lector.setConsulta("Insert into DISCOS (Titulo,CantidadCanciones, UrlImagenTapa, IdEstilo, IdTipoEdicion, FechaLanzamiento) values (@Titulo,@CantidadCanciones,@UrlImagenTapa,@IdEstilo,@IdTipoEdicion,@FechaLanzamiento)");
                lector.ejecutarAccion();
                lector.cerrarConexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void modificarDisco(Disco disco)
        {
            LecturaRegistros sql = new LecturaRegistros("server=.\\SQLEXPRESS; database=DISCOS_DB; integrated security=true");
            try
            {
                sql.setConsulta("update DISCOS set Titulo = @Titulo, FechaLanzamiento = @Fecha, CantidadCanciones = @CantCanciones, UrlImagenTapa = @UrlImagen, IdEstilo = @IdEstilo, IdTipoEdicion = @IdTipoEdicion Where Id = @Id");
                sql.setearParametro("@Titulo", disco.Name);
                sql.setearParametro("@Fecha", disco.Fecha.ToString("d"));
                sql.setearParametro("@CantCanciones", disco.Tracks);
                sql.setearParametro("@UrlImagen", disco.UrlImagen);
                sql.setearParametro("@IdEstilo",disco.Genre.Id);
                sql.setearParametro("@IdTipoEdicion", disco.Formato.Id);
                sql.setearParametro("@Id", disco.ID);

                sql.ejecutarAccion();




            }catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sql.cerrarConexion();
            }
        }

        public void eliminarDiscoFisico(int id)
        {
            LecturaRegistros sql = new LecturaRegistros("server=.\\SQLEXPRESS; database=DISCOS_DB; integrated security=true");
            try
            {
                sql.setConsulta("delete from DISCOS where Id=@Id");
                sql.setearParametro("@Id", id);
                sql.ejecutarAccion();

            }catch (Exception ex)
            {
                throw ex;
            }finally { sql.cerrarConexion(); }
        }

        public List<Disco> filtrar(string campo, string criterio, string filtro)
        {
            List<Disco> lista = new List<Disco>();
            LecturaRegistros sql = new LecturaRegistros("server=.\\SQLEXPRESS; database=DISCOS_DB; integrated security=true");
            try
            {
                string consulta = "Select D.Id,Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa, E.Descripcion as EstiloMusical,E.Id as IdEstilo, T.Descripcion as Formato, T.Id as IdFormato from DISCOS D, ESTILOS E, TIPOSEDICION T Where D.IdEstilo = E.Id and T.Id = D.IdTipoEdicion and ";
                switch (campo)
                {
                    case "Nombre":
                        switch (criterio)
                        {
                            case "Inicia con ":
                                consulta += "Titulo like '" + filtro + "%'";
                                break;
                            case "Termina con ":
                                consulta += "Titulo like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "Titulo like '%" + filtro + "%'";
                                break;
                        }
                        break;
                    case "Año":
                        switch (criterio)
                        {
                            case "Es menor a ":
                                consulta += "YEAR(FechaLanzamiento) < '" + filtro + "'";
                                break;
                            case "Es mayor a ":
                                consulta += "YEAR(FechaLanzamiento) > '" + filtro + "'";
                                break;
                            default:
                                consulta += "YEAR(FechaLanzamiento) = '" + filtro + "'";
                                break;
                        }
                        break;
                    default:
                        switch (criterio)
                        {
                            case "Es menor a ":
                                consulta += "CantidadCanciones < '" + filtro + "'";
                                break;
                            case "Es mayor a ":
                                consulta += "CantidadCanciones > '" + filtro + "'";
                                break;
                            default:
                                consulta += "CantidadCanciones = '" + filtro + "'";
                                break;
                        }
                        break;
                }
                sql.setConsulta(consulta);
                sql.realizarConsulta();
                while (sql.Lector.Read())
                {
                    Disco disco = new Disco();
                    disco.ID = (int)sql.Lector["Id"];
                    disco.Name = (string)sql.Lector["Titulo"];
                    disco.Fecha = (DateTime)sql.Lector["FechaLanzamiento"];
                    disco.UrlImagen = (string)sql.Lector["UrlImagenTapa"];
                    disco.Tracks = (int)sql.Lector["CantidadCanciones"];
                    disco.Genre = new Estilo();
                    disco.Genre.Id = (int)sql.Lector["IdEstilo"];
                    disco.Genre.Description = (string)sql.Lector["EstiloMusical"];
                    disco.Formato = new Estilo();
                    disco.Formato.Id = (int)sql.Lector["IdFormato"];
                    disco.Formato.Description = (string)sql.Lector["Formato"];
                    lista.Add(disco);
                }

                sql.cerrarConexion();
                return lista;
            }catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
