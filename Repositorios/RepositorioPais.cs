using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorio;
using Repositorios.UtilidadesBD;

namespace Repositorios
{
    public class RepositorioPais : IRepositorioPais
    {
        public IEnumerable<Pais> FindAll()
        {
            Conexion manejadorConexion = new Conexion();
            SqlConnection con = manejadorConexion.CrearConexion();

            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Paises", con);
                manejadorConexion.AbrirConexion(con);
                SqlDataReader dataReader = cmd.ExecuteReader();

                List<Pais> paises = new List<Pais>();

                while (dataReader.Read())
                {
                    Pais unPais = new Pais()
                    {
                        CodPais = (string)dataReader["CodPais"],
                        Nombre = (string)dataReader["Nombre"]
                    };

                    paises.Add(unPais);
                }
                dataReader.Close();

                return paises;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Assert(false, "Error al listar paises" + e.Message);
                return null;
            }
            finally
            {
                manejadorConexion.CerrarConexion(con);
            }
        }
    }
}
