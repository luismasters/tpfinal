﻿using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ImagenNegocio
    {


        public List<Imagen> Listar(int articuloId)
        {
            List<Imagen> imagenes = new List<Imagen>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT ImagenUrl FROM IMAGENES WHERE IdPrenda = @idArticulo");
                datos.agregarParametro("@idArticulo", articuloId);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Imagen imagen = new Imagen
                    {
                        IdPrenda = articuloId,
                        ImagenURL = (string)datos.Lector["ImagenUrl"]
                    };
                    imagenes.Add(imagen);
                }

                return imagenes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void Agregar(string url, int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO IMAGENES (ImagenUrl, IdPrenda) VALUES (@Url, @IdPrenda)");
                datos.agregarParametro("@Url", url);
                datos.agregarParametro("@IdPrenda", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public void Modificar(Imagen imagen)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update IMAGENES set ImagenUrl = @imagenUrl, IdPrenda = @idArticulo where IdPrenda = @id");
                datos.agregarParametro("@imagenUrl", imagen.ImagenURL);
                datos.agregarParametro("@idPrenda", imagen.IdPrenda);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void Eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Delete From IMAGENES Where idPrenda = @id");
                datos.agregarParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
