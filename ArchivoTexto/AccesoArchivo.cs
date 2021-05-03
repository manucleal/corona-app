using System;
using System.IO;
using System.Data.SqlClient;
using Repositorios.UtilidadesBD;

namespace ArchivoTexto
{
    public class AccesoArchivo
    {
        private static string nombreArchivoLaboratorio = "Laboratorios.txt";
        private static string nombreArchivoStatusVacuna = "StatusVacuna.txt";
        private static string nombreArchivoTipoVacunas= "TipoVacunas.txt";
        private static string nombreArchivoUsuarios= "Usuarios.txt";
        private static string nombreArchivoVacunaLaboratorios= "VacunaLaboratorios.txt";
        private static string nombreArchivoVacunas = "Vacunas.txt";
        private static string nombreArchivoPaises = "Paises.txt";
        private static string carpeta = "ExportTablas";
        private static string raiz = AppDomain.CurrentDomain.BaseDirectory;

        public static void GenerarArchivos()
        {
            GuardarArchivoLaboratorios();
            GuardarArchivoStatusVacuna();
            GuardarArchivoTipoVacunas();
            GuardarArchivoUsuarios();
            GuardarArchivoVacunaLaboratorios();
            GuardarArchivoVacunas();
            GuardarArchivoPaises();
        }

        public static bool GuardarArchivoLaboratorios()
        {

            Conexion handler = new Conexion();
            SqlConnection con = new Conexion().CrearConexion();

            try
            {
                SqlCommand cmd = new SqlCommand("Select * from Laboratorios", con);

                if (handler.AbrirConexion(con))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    StreamWriter sr = new StreamWriter(Path.Combine(raiz, carpeta, nombreArchivoLaboratorio));
                    while (dr.Read())
                    {
                        int id = (int)dr["Id"];
                        string nombre = dr["Nombre"].ToString();
                        string paisOrigen = dr["PaisOrigen"].ToString();
                        string experiencia = ((bool)dr["Experiencia"] ? "Si" : "NO");
                        sr.WriteLine($"{id} | {nombre} | {paisOrigen} | {experiencia}");
                    }
                    dr.Close();
                    sr.Close();
                    return true;
                }
                return false;
            }
            catch(IOException ex)
            {
                System.Diagnostics.Debug.Assert(false, "Error al grabar la tabla laboratorios" + ex.Message);
                return false;
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.Assert(false, "Error al grabar la tabla laboratorios" + ex.Message);
                return false;
            }
            finally
            {
                handler.CerrarConexion(con);
            }

        }

        public static bool GuardarArchivoStatusVacuna()
        {

            Conexion handler = new Conexion();
            SqlConnection con = new Conexion().CrearConexion();

            try
            {
                SqlCommand cmd = new SqlCommand("Select * from StatusVacuna", con);

                if (handler.AbrirConexion(con))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    StreamWriter sr = new StreamWriter(Path.Combine(raiz, carpeta, nombreArchivoStatusVacuna));
                    while (dr.Read())
                    {
                        int idVac = (int)dr["IdVac"];
                        string codPais = dr["CodPais"].ToString();
                        sr.WriteLine($"{idVac} | {codPais}");
                    }
                    dr.Close();
                    sr.Close();
                    return true;
                }
                return false;
            }
            catch (IOException ex)
            {
                System.Diagnostics.Debug.Assert(false, "Error al grabar la tabla StatusVacuna" + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Assert(false, "Error al grabar la tabla StatusVacuna" + ex.Message);
                return false;
            }
            finally
            {
                handler.CerrarConexion(con);
            }

        }

        public static bool GuardarArchivoTipoVacunas()
        {

            Conexion handler = new Conexion();
            SqlConnection con = new Conexion().CrearConexion();

            try
            {
                SqlCommand cmd = new SqlCommand("Select * from TipoVacunas", con);

                if (handler.AbrirConexion(con))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    StreamWriter sr = new StreamWriter(Path.Combine(raiz, carpeta, nombreArchivoTipoVacunas));
                    while (dr.Read())
                    {
                        string id = dr["Id"].ToString();
                        string descripcion = dr["Descripcion"].ToString();
                        sr.WriteLine($"{id} | {descripcion}");
                    }
                    dr.Close();
                    sr.Close();
                    return true;
                }
                return false;
            }
            catch (IOException ex)
            {
                System.Diagnostics.Debug.Assert(false, "Error al grabar la tabla tipoVacunas" + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Assert(false, "Error al grabar la tabla tipoVacunas" + ex.Message);
                return false;
            }
            finally
            {
                handler.CerrarConexion(con);
            }

        }

        public static bool GuardarArchivoUsuarios()
        {

            Conexion handler = new Conexion();
            SqlConnection con = new Conexion().CrearConexion();

            try
            {
                SqlCommand cmd = new SqlCommand("Select * from Usuarios", con);

                if (handler.AbrirConexion(con))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    StreamWriter sr = new StreamWriter(Path.Combine(raiz, carpeta, nombreArchivoUsuarios));
                    while (dr.Read())
                    {
                        string documento = dr["Documento"].ToString();
                        string nombre = dr["Nombre"].ToString();
                        string password = dr["Password"].ToString();
                        sr.WriteLine($"{documento} | {nombre} | {password}");
                    }
                    dr.Close();
                    sr.Close();
                    return true;
                }
                return false;
            }
            catch (IOException ex)
            {
                System.Diagnostics.Debug.Assert(false, "Error al grabar la tabla Usuarios" + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Assert(false, "Error al grabar la tabla Usuarios" + ex.Message);
                return false;
            }
            finally
            {
                handler.CerrarConexion(con);
            }

        }

        public static bool GuardarArchivoVacunaLaboratorios()
        {

            Conexion handler = new Conexion();
            SqlConnection con = new Conexion().CrearConexion();

            try
            {
                SqlCommand cmd = new SqlCommand("Select * from VacunaLaboratorios", con);

                if (handler.AbrirConexion(con))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    StreamWriter sr = new StreamWriter(Path.Combine(raiz, carpeta, nombreArchivoVacunaLaboratorios));
                    while (dr.Read())
                    {
                        int idVacuna = (int)dr["IdVacuna"];
                        int idLaboratorio= (int)dr["Idlaboratorio"];
                        sr.WriteLine($"{idVacuna} | {idLaboratorio}");
                    }
                    dr.Close();
                    sr.Close();
                    return true;
                }
                return false;
            }
            catch (IOException ex)
            {
                System.Diagnostics.Debug.Assert(false, "Error al grabar la tabla VacunaLoratorios" + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Assert(false, "Error al grabar la tabla VacunaLoratorios" + ex.Message);
                return false;
            }
            finally
            {
                handler.CerrarConexion(con);
            }

        }

        public static bool GuardarArchivoVacunas()
        {

            Conexion handler = new Conexion();
            SqlConnection con = new Conexion().CrearConexion();

            try
            {
                SqlCommand cmd = new SqlCommand("Select * from Vacunas", con);

                if (handler.AbrirConexion(con))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    StreamWriter sr = new StreamWriter(Path.Combine(raiz, carpeta, nombreArchivoVacunas));
                    while (dr.Read())
                    {
                        int id = (int)dr["Id"];
                        string idTipoVac = dr["IdTipo"].ToString();
                        string idUsuario = dr["IdUsuario"].ToString();
                        string nombre = dr["Nombre"].ToString();
                        int cantDosis = (int)dr["CantidadDosis"];
                        int lapsoDiasDosis = (int)dr["LapsoDiasDosis"];
                        int maxEdad = (int)dr["MaxEdad"];
                        int minEdad = (int)dr["MinEdad"];
                        int eficaciaPrev = (int)dr["EficaciaPrev"];
                        int eficaciaHosp = (int)dr["EficaciaHosp"];
                        int eficaciaCti = (int)dr["EficaciaCti"];
                        int maxTemp = (int)dr["MaxTemp"];
                        int minTemp = (int)dr["MinTemp"];
                        long produccionAnual = (long)dr["ProduccionAnual"];
                        int faseClinicaAprob = (int)dr["FaseClinicaAprob"];
                        string emergencia = ((bool)dr["Emergencia"] ? "Si" : "NO");
                        string efectosAdversos = dr["EfectosAdversos"].ToString();
                        decimal precio = (decimal)dr["Precio"];
                        string ultimaModificacion = dr["UltimaModificacion"].ToString();
                        string covax = ((bool)dr["Covax"] ? "Si" : "NO");
                        sr.WriteLine($"{id} | {idTipoVac} | {idUsuario} | {nombre} | {cantDosis} | {lapsoDiasDosis} | {maxEdad} | " +
                            $"{minEdad} | {eficaciaPrev} | {eficaciaHosp} | {eficaciaCti} | {maxTemp} | {minTemp} | {produccionAnual}" +
                            $" | {faseClinicaAprob} | {emergencia} | {efectosAdversos} | {precio} | {ultimaModificacion} | {covax}");
                    }
                    dr.Close();
                    sr.Close();
                    return true;
                }
                return false;
            }
            catch (IOException ex)
            {
                System.Diagnostics.Debug.Assert(false, "Error al grabar la tabla Vacunas" + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Assert(false, "Error al grabar la tabla Vacunas" + ex.Message);
                return false;
            }
            finally
            {
                handler.CerrarConexion(con);
            }

        }

        public static bool GuardarArchivoPaises()
        {

            Conexion handler = new Conexion();
            SqlConnection con = new Conexion().CrearConexion();

            try
            {
                SqlCommand cmd = new SqlCommand("Select * from Paises", con);

                if (handler.AbrirConexion(con))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    StreamWriter sr = new StreamWriter(Path.Combine(raiz, carpeta, nombreArchivoPaises));
                    while (dr.Read())
                    {
                        string codPais = dr["CodPais"].ToString();
                        string nombre = dr["Nombre"].ToString();
                        sr.WriteLine($"{codPais} | {nombre}");
                    }
                    dr.Close();
                    sr.Close();
                    return true;
                }
                return false;
            }
            catch (IOException ex)
            {
                System.Diagnostics.Debug.Assert(false, "Error al grabar la tabla Paises" + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Assert(false, "Error al grabar la tabla Paises" + ex.Message);
                return false;
            }
            finally
            {
                handler.CerrarConexion(con);
            }

        }



    }
}
