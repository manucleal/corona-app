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
        public bool Add(Laboratorio unLaboratorio)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Laboratorio> FindAll()
        {
            try
            {
                Conexion manejadorConexion = new Conexion();
                SqlConnection con = manejadorConexion.crearConexion();
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

        public Laboratorio FindByAll(string nombre)
        {
            throw new NotImplementedException();
        }

        public Laboratorio FindById(int idLaboratorio)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int idLaboratorio)
        {
            throw new NotImplementedException();
        }

        public bool Update(Laboratorio unLaboratorio)
        {
            throw new NotImplementedException();
        }
    }
}
