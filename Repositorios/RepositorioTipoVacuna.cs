using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorio;
using Repositorios.UtilidadesBD;

namespace Repositorios
{
    public class RepositorioTipoVacuna : IRepositorioTipoVacuna
    {
        public bool Add(TipoVacuna unTipoVacuna)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TipoVacuna> FindAll()
        {
            try
            {
                Conexion manejadorConexion = new Conexion();
                SqlConnection con = manejadorConexion.crearConexion();
                SqlCommand cmd = new SqlCommand("SELECT * FROM TipoVacunas", con);

                manejadorConexion.AbrirConexion(con);
                SqlDataReader dataReader = cmd.ExecuteReader();
                manejadorConexion.CerrarConexion(con);
                List<TipoVacuna> tipoVacunas = new List<TipoVacuna>();

                while (dataReader.Read())
                {
                    tipoVacunas.Add(new TipoVacuna
                    {
                        Id = (string)dataReader["Id"],
                        Descripcion = (string)dataReader["Descripcion"]
                    });
                }
                return tipoVacunas;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Assert(false, "Error al listar Tipo de Vacunas" + e.Message);
                return null;
            }
        }

        public TipoVacuna FindById(string idTipoVacuna)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int idTipoVacuna)
        {
            throw new NotImplementedException();
        }

        public bool Update(TipoVacuna unTipoVacuna)
        {
            throw new NotImplementedException();
        }
    }
}
