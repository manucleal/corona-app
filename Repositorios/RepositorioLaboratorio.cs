using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorio;
using Repositorios.UtilidadesBD;

namespace Repositorios
{
    public class RepositorioLaboratorio : IRepositorioLaboratorio
    {
        public IEnumerable<Laboratorio> FindAll()
        {
            try
            {
                Conexion manejadorConexion = new Conexion();
                SqlConnection con = manejadorConexion.CrearConexion();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Laboratorios", con);

                manejadorConexion.AbrirConexion(con);
                SqlDataReader dataReader = cmd.ExecuteReader();
                manejadorConexion.CerrarConexion(con);
                List<Laboratorio> laboratorios = new List<Laboratorio>();

                while (dataReader.Read())
                {
                    laboratorios.Add(new Laboratorio
                    {
                        Id = (int)dataReader["Id"],
                        Nombre = (string)dataReader["Nombre"],
                        PaisOrigen = (string)dataReader["PaisOrigen"],
                        Experiencia = (bool)dataReader["Experiencia"],
                    });
                }
                return laboratorios;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Assert(false, "Error al ingresar Laboratorio" + e.Message);
                return null;
            }
        }
    }
}
