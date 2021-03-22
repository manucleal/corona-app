using System;
using System.Data.SqlClient;

namespace Repositorios.UtilidadesBD
{
    public class Conexion
    {
        public string stringConecction { get; set; }

        public SqlConnection crearConexion()
        {
            return new SqlConnection(stringConecction);
        }

        public Conexion()
        {
            stringConecction = System.Configuration.ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        }

        public bool AbrirConexcion(SqlConnection con)
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

        public bool CerrarConexcion(SqlConnection con)
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
