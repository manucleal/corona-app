using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
