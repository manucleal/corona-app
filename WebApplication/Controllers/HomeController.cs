using System.Web.Mvc;
using System.Data.SqlClient;
using Dominio.EntidadesNegocio;
using Repositorios.RepositorioVacuna;
using System;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //agregando vacuna
            Vacuna Vacuna = new Vacuna();
            Vacuna.Nombre = "Nombre Vacuna 1";
            Vacuna.CantidadDosis = 2;
            Vacuna.LapsoDiasDosis = 20;
            Vacuna.RangoEdad = 50-60;
            Vacuna.EfPrev = 65;
            Vacuna.EfHosp = 80;
            Vacuna.EfCti = 75;
            Vacuna.RangoTemp = -10;
            Vacuna.ProduccionAnual = 1000000;
            Vacuna.FaseClinicaAprob = 3;
            Vacuna.Emergencia = false;
            Vacuna.EfectosAdversos = "fiebre y dolor de cabeza";
            Vacuna.Precio = 100;
            Vacuna.UltimaModificacion = new DateTime();
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