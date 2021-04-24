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
            Conexion manejadorConexion = new Conexion();
            SqlConnection cn = manejadorConexion.crearConexion();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Vacunas WHERE Email=@email", cn);

                //cmd.Parameters.AddWithValue("@email", mail);
                manejadorConexion.AbrirConexion(cn);
                SqlDataReader dr = cmd.ExecuteReader();
                Vacuna cli = null;
                if (dr.HasRows)
                {
                    cli = new Vacuna();
                    if (dr.Read())
                    {
                        //cli.Nombre = dr["Nombre"].ToString();
                        //cli.Apellido = dr["Apellido"].ToString();
                        //cli.Email = mail;
                        //cli.Password = dr["Password"].ToString();
                    }
                    dr.NextResult();
                    while (dr.Read())
                    {
                        //cli.MisTelefonos.Add(new Telefono
                        //{
                        //    CodigoArea = (int)dr["CodArea"],
                        //    Numero = (int)dr["Numero"],
                        //    EsCelular = (bool)dr["EsCelular"]
                        //});
                    }
                }
                return new List<Vacuna>();
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                manejadorConexion.CerrarConexion(cn);
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
