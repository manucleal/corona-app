﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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

                SqlCommand cmd = new SqlCommand("INSERT INTO Vacunas output INSERTED.ID VALUES (@IdTipo,@IdUsuario,@Nombre,@CantidadDosis," +
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
                    int modified = (int)cmd.ExecuteScalar();

                    SqlCommand cmd2 = new SqlCommand("INSERT INTO VacunaLaboratorios VALUES (@IdVacuna,@IdLaboratorio)", con);
                    foreach (int lab in unaVacuna.Laboratorios)
                    {
                        cmd2.Parameters.Clear();
                        cmd2.Parameters.AddWithValue("@IdVacuna", (int)modified);
                        cmd2.Parameters.AddWithValue("@IdLaboratorio", (int)lab);
                        cmd2.ExecuteNonQuery();
                    }
                    handler.CerrarConexion(con);
                    return true;
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
            Conexion manejadorConexion = new Conexion();
            SqlConnection con = manejadorConexion.crearConexion();

            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Vacunas", con);
                manejadorConexion.AbrirConexion(con);
                SqlDataReader dataReader = cmd.ExecuteReader();
                
                List<Vacuna> vacunas = new List<Vacuna>();

                while (dataReader.Read())
                {
                    int idVacuna = (int)dataReader["Id"];
                    Vacuna unaVacuna = new Vacuna()
                    {
                        Id = idVacuna,
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
                    };

                    vacunas.Add(unaVacuna);

                    SqlCommand query = new SqlCommand("SELECT * FROM Laboratorios l " +
                                                      "WHERE l.Id IN (SELECT IdLaboratorio FROM VacunaLaboratorios vl " + 
                                                      "WHERE IdVacuna=@IdVacuna)", con);
                    query.Parameters.AddWithValue("@IdVacuna", idVacuna);
                    SqlDataReader labs = query.ExecuteReader();

                    while (labs.Read())
                    {
                        Laboratorio lab = new Laboratorio()
                        {
                            Id = (int)labs["Id"],
                            Nombre = (string)labs["Nombre"],
                            PaisOrigen = (string)labs["PaisOrigen"],
                            Experiencia = (bool)labs["Experiencia"]
                        };

                        unaVacuna.ListaLaboratorios.Add(lab);
                    }

                    labs.Close();
                }
                dataReader.Close();

                return vacunas;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Assert(false, "Error al ingresar Vacuna" + e.Message);
                return null;
            }
            finally
            {
                manejadorConexion.CerrarConexion(con);
            }
        }

        public IEnumerable<Vacuna> FindAllByName(string nombre)
        {
            Conexion manejadorConexion = new Conexion();
            SqlConnection con = manejadorConexion.crearConexion();

            try
            {
                SqlCommand query = new SqlCommand("Select * from Vacunas where Nombre = @Nombre", con);
                manejadorConexion.AbrirConexion(con);

                query.Parameters.AddWithValue("@Nombre", nombre);
                SqlDataReader dataReader = query.ExecuteReader();

                List<Vacuna> vacunas = new List<Vacuna>();

                while (dataReader.Read())
                {
                    Vacuna unaVacuna = new Vacuna()
                    {
                        Nombre = (string)dataReader["Nombre"],
                        IdTipo = (string)dataReader["IdTipo"],
                        Precio = (decimal)dataReader["Precio"],

                    };
                    vacunas.Add(unaVacuna);
                }
                return vacunas;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Assert(false, "Error al listar vacunas por nombre" + e.Message);
                return null;
            }
            finally
            {
                manejadorConexion.CerrarConexion(con);
            }
        }

        public IEnumerable<Vacuna> FindAllByApprovalPhase(int FaseClinicaAprob)
        {
            Conexion manejadorConexion = new Conexion();
            SqlConnection con = manejadorConexion.crearConexion();

            try
            {
                SqlCommand query = new SqlCommand("Select * from Vacunas where FaseClinicaAprob = @FaseClinicaAprob", con);
                manejadorConexion.AbrirConexion(con);

                query.Parameters.AddWithValue("@FaseClinicaAprob", FaseClinicaAprob);
                SqlDataReader dataReader = query.ExecuteReader();

                List<Vacuna> vacunas = new List<Vacuna>();

                while (dataReader.Read())
                {
                    Vacuna unaVacuna = new Vacuna()
                    {
                        Nombre = (string)dataReader["Nombre"],
                        IdTipo = (string)dataReader["IdTipo"],
                        Precio = (decimal)dataReader["Precio"],

                    };
                    vacunas.Add(unaVacuna);
                }
                return vacunas;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Assert(false, "Error al listar vacunas por fase clinica aprobacion" + e.Message);
                return null;
            }
            finally
            {
                manejadorConexion.CerrarConexion(con);
            }
        }

        public IEnumerable<Vacuna> FindAllByCountry(string pais)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vacuna> FindAllByIdTypeVac(int idVac)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vacuna> FindAllByIdVac(int idVac)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vacuna> FindAllByLabName(string nombreLab)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vacuna> FindAllByMaxPrice(int precioMax)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vacuna> FindAllByMinPrice(int precioMin)
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
