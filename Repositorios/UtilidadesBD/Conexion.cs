using System;
using System.Data.SqlClient;

namespace Repositorios.UtilidadesBD
{
    public class Conexion
    {
        public string StringConecction { get; set; }

        public SqlConnection crearConexion()
        {
            return new SqlConnection(StringConecction);
        }

        public Conexion()
        {
            StringConecction = System.Configuration.ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        }

        public bool AbrirConexion(SqlConnection con)
        {
            if (con == null) return false;
            try
            {
                if(con.State != System.Data.ConnectionState.Open)
                {
                    con.Open();
                    return true;
                }
                return false;
            }
            catch (Exception exp)
            {
                System.Diagnostics.Debug.Assert(false, "Error al abrir la conexión" + exp.Message);
                return false;
            }
        }

        public bool CerrarConexion(SqlConnection con)
        {
            if (con == null) return false;
            try
            {
                if (con.State != System.Data.ConnectionState.Open)
                {
                    con.Close();
                    return true;
                }
                return false;
            }
            catch (Exception exp)
            {
                System.Diagnostics.Debug.Assert(false, "Error al cerrar la conexión" + exp.Message);
                return false;
            }
        }
    }
}
