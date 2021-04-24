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

                cmd.Parameters.AddWithValue("@Nombre", unaVacuna.Nombre);
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

                if (handler.AbrirConexion(con))
                {
                    int filas = cmd.ExecuteNonQuery();
                    handler.CerrarConexion(con);
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
            try
            {
                Conexion manejadorConexion = new Conexion();
                SqlConnection cn = manejadorConexion.crearConexion();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Vacunas", cn);

                //cmd.Parameters.AddWithValue("@email", mail);
                manejadorConexion.AbrirConexion(cn);
                SqlDataReader dr = cmd.ExecuteReader();
                manejadorConexion.CerrarConexion(cn);
                List<Vacuna> vacunas = new List<Vacuna>();

                while (dr.Read())
                {
                    vacunas.Add(new Vacuna
                    {
                        Id = (int)dr["Id"],
                        Nombre = (string)dr["Nombre"],
                        IdTipo = (string)dr["IdTipo"],
                        CantidadDosis = (int)dr["CantidadDosis"],
                        LapsoDiasDosis = (int)dr["LapsoDiasDosis"],
                        MaxEdad = (int)dr["MaxEdad"],
                        MinEdad = (int)dr["MinEdad"],
                        EficaciaPrev = (int)dr["EficaciaPrev"],
                        EficaciaHosp = (int)dr["EficaciaHosp"],
                        EficaciaCti = (int)dr["EficaciaCti"],
                        MaxTemp = (int)dr["MaxTemp"],
                        MinTemp = (int)dr["MinTemp"],
                        ProduccionAnual = (int)dr["ProduccionAnual"],
                        FaseClinicaAprob = (int)dr["FaseClinicaAprob"],
                        Emergencia = (bool)dr["Emergencia"],
                        EfectosAdversos = (string)dr["EfectosAdversos"],
                        Precio = (decimal)dr["Precio"],
                        IdUsuario = (string)dr["IdUsuario"]
                    });
                }
                return vacunas;
            }
            catch (Exception e)
            {
                return null;
            }
            //finally
            //{
            //    manejadorConexion.CerrarConexion(cn);
            //}
        }

        public Vacuna FindByAll(string nombre)
        {
            throw new NotImplementedException();
        }

        public Vacuna FindById(int idVacuna)
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
