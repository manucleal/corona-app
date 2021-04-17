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
            //if (unaVacuna == null || !unaVacuna.Validar())
            //{
            //    return false;
            //}

            try
            {
                Conexion handler = new Conexion();
                SqlConnection con = new Conexion().crearConexion();

                SqlCommand cmd = new SqlCommand("INSERT INTO Vacunas VALUES (@Nombre,@IdTipo,@CantidadDosis," +
                    "@LapsoDiasDosis,@MaxEdad,@MinEdad,@EficaciaPrev,@EficaciaHosp,@EficaciaCti,@MaxTemp,@MinTemp,@ProduccionAnual,@FaseClinicaAprob," +
                    "@Emergencia,@EfectosAdversos,@Precio,@IdUsuario,@IdTipo)", con);

                cmd.Parameters.AddWithValue("@nombre", unaVacuna.Nombre);
                cmd.Parameters.AddWithValue("@IdTipo","VV");
                cmd.Parameters.AddWithValue("@CantidadDosis", unaVacuna.CantidadDosis);
                cmd.Parameters.AddWithValue("@LapsoDiasDosis", unaVacuna.LapsoDiasDosis);
                cmd.Parameters.AddWithValue("@MaxEdad", unaVacuna.MaxEdad);
                cmd.Parameters.AddWithValue("@MinEdad", unaVacuna.MinEdad);
                cmd.Parameters.AddWithValue("@EficaciaPrev", unaVacuna.EficaciaPrev);
                cmd.Parameters.AddWithValue("@EficaciaHosp", unaVacuna.EficaciaHosp);
                cmd.Parameters.AddWithValue("@EficaciaCti", unaVacuna.EficaciaCti);
                cmd.Parameters.AddWithValue("@MaxTemp", unaVacuna.MaxTemp);
                cmd.Parameters.AddWithValue("@MinTemp", unaVacuna.MinTemp);
                cmd.Parameters.AddWithValue("@ProduccionAnual", unaVacuna.ProduccionAnual);
                cmd.Parameters.AddWithValue("@FaseClinicaAprob", unaVacuna.FaseClinicaAprob);
                cmd.Parameters.AddWithValue("@Emergencia", unaVacuna.Emergencia);
                cmd.Parameters.AddWithValue("@EfectosAdversos", unaVacuna.EfectosAdversos);
                cmd.Parameters.AddWithValue("@Precio", unaVacuna.Precio);
                cmd.Parameters.AddWithValue("@IdUsuario", unaVacuna.IdUsuario);
                cmd.Parameters.AddWithValue("@IdTipo", unaVacuna.IdTipo);

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

        public Vacuna FindById(int idVacuna)
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
