using System.Web.Mvc;
using System.Data.SqlClient;
using Dominio.EntidadesNegocio;
using Repositorios;
using System;
using ArchivoTexto;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            AccesoArchivo.GenerarArchivos();
            return View();
        }
        // GET: Home
        //public ActionResult Index()
        //{
            //SqlConnection myConnection = new SqlConnection();
            
            //Hardcodeado en el controller
            //myConnection.ConnectionString = @"SERVER=(localDb)\MsSqlLocalDb;
            //                                DATABASE=database_p3; 
            //                                INTEGRATED SECURITY=TRUE";
            
            //Desde web config
            //myConnection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;

            //ViewBag.Message = "Database Connected! ";
            //myConnection.Open();
            //consultas
            //myConnection.Close();
            //Dominio.Helpers.Validacion;


            //if (AltaCategoria())
            //{
            //    ViewBag.Message = "Se dio de alta";
            //}
            //else
            //{
            //    ViewBag.Message = "No se dio de alta";
            //}
            //return View();
        //}

        private bool AltaCategoria()
        {
            SqlConnection myConnection = new SqlConnection();
            //Desde web config
            myConnection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConnection;
            cmd.CommandText = "INSERT INTO Usuario VALUES ('1','Emanuel','46902781','12345')";
            myConnection.Open();

            int filasAfectadas = cmd.ExecuteNonQuery();
            myConnection.Close();
            if (filasAfectadas > 0){
                return true;
            }
            return false;
        }
    }
}