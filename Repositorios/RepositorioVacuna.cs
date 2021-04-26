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
            try
            {
                Conexion handler = new Conexion();
                SqlConnection con = new Conexion().crearConexion();

                SqlCommand cmd = new SqlCommand("INSERT INTO Vacunas VALUES (@IdTipo,@IdUsuario,@Nombre,@CantidadDosis," +
                    "@LapsoDiasDosis,@MaxEdad,@MinEdad,@EficaciaPrev,@EficaciaHosp,@EficaciaCti,@MaxTemp,@MinTemp," + 
                    "@ProduccionAnual,@FaseClinicaAprob,@Emergencia,@EfectosAdversos,@Precio,@UltimaModificacion,@Covax)", con);
                
                cmd.Parameters.AddWithValue("@IdTipo", unaVacuna.IdTipo);
                cmd.Parameters.AddWithValue("@IdUsuario", unaVacuna.IdUsuario);
                cmd.Parameters.AddWithValue("@Nombre", unaVacuna.Nombre);
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
                cmd.Parameters.AddWithValue("@UltimaModificacion", DateTime.Now);
                cmd.Parameters.AddWithValue("@Covax", unaVacuna.Covax);

                if (handler.AbrirConexion(con))
                {
                    int filas = cmd.ExecuteNonQuery();
                    handler.CerrarConexion(con);
                    return filas >= 1;
                }
                return false;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Assert(false, "Error al ingresar Vacuna" + e.Message);
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

                manejadorConexion.AbrirConexion(cn);
                SqlDataReader dataReader = cmd.ExecuteReader();
                manejadorConexion.CerrarConexion(cn);
                List<Vacuna> vacunas = new List<Vacuna>();

                while (dataReader.Read())
                {
                    vacunas.Add(new Vacuna
                    {
                        Id = (int)dataReader["Id"],
                        Nombre = (string)dataReader["Nombre"],
                        IdTipo = (string)dataReader["IdTipo"],
                        CantidadDosis = (int)dataReader["CantidadDosis"],
                        LapsoDiasDosis = (int)dataReader["LapsoDiasDosis"],
                        MaxEdad = (int)dataReader["MaxEdad"],
                        MinEdad = (int)dataReader["MinEdad"],
                        EficaciaPrev = (int)dataReader["EficaciaPrev"],
                        EficaciaHosp = (int)dataReader["EficaciaHosp"],
                        EficaciaCti = (int)dataReader["EficaciaCti"],
                        MaxTemp = (int)dataReader["MaxTemp"],
                        MinTemp = (int)dataReader["MinTemp"],
                        ProduccionAnual = (int)dataReader["ProduccionAnual"],
                        FaseClinicaAprob = (int)dataReader["FaseClinicaAprob"],
                        Emergencia = (bool)dataReader["Emergencia"],
                        EfectosAdversos = (string)dataReader["EfectosAdversos"],
                        Precio = (decimal)dataReader["Precio"],
                        IdUsuario = (string)dataReader["IdUsuario"]
                    });
                }
                return vacunas;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Assert(false, "Error al ingresar Vacuna" + e.Message);
                return null;
            }
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
