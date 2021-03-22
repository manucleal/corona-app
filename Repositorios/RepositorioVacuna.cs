using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorio;
using Repositorios.UtilidadesBD;

namespace Repositorios
{
    public class RepositorioVacuna : IRepositorioVacuna

    {
        public bool Add(Vacuna unaVacuna)
        {
            if (unaVacuna == null || !unaVacuna.Validar())
            {
                return false;
            }

            Conexion handler = new Conexion();
            SqlConnection con = new Conexion().crearConexion();
            SqlCommand cmd = new SqlCommand("INSERT INTO Vacunas VALUES (@nombre)", con);
            cmd.Parameters.Add(new SqlParameter("@nombre", "variable"));
            try
            {
                if (handler.AbrirConexcion(con))
                {
                    int filas = cmd.ExecuteNonQuery();
                    handler.CerrarConexcion(con);
                    return filas >= 1;
                }
                return false;
            }
            catch (Exception exp)
            {

                System.Diagnostics.Debug.Assert(false, "Error al ingresar Vacuna" + exp.Message);
                return false;
            }
        }

        public IEnumerable<Vacuna> FindAll()
        {
            throw new NotImplementedException();
        }

        public Vacuna FindByAll(string nombre)
        {
            throw new NotImplementedException();
        }

        public Vacuna FingById(int idVacuna)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int idVacuna)
        {
            throw new NotImplementedException();
        }

        public bool Update(Vacuna unaVacuna)
        {
            throw new NotImplementedException();
        }
    }
}
