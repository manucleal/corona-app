using System;
using System.Web.Mvc;
using Repositorios;
using Dominio.EntidadesNegocio;

namespace WebApplication.Controllers
{
    public class VacunaController : Controller
    {
        // GET: Vacuna
        public ActionResult Index()
        {

            if ((string)Session["documento"] == null)
            {
                Session["documento"] = null;
                Session["nombre"] = null;
                return RedirectToAction("Login", "Usuario");
            }

            RepositorioVacuna repoVacuna = new RepositorioVacuna();
            repoVacuna.FindAll();

            return View(repoVacuna.FindAll());
        }

        [HttpGet]
        public ActionResult Alta()
        {
            if ((string)Session["documento"] == null)
            {
                Session["documento"] = null;
                Session["nombre"] = null;
                return RedirectToAction("Login", "Usuario");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Alta(Vacuna unaVacuna)
        {
            unaVacuna.IdUsuario = (string)Session["documento"];
            unaVacuna.ProduccionAnual = 1000000;
            unaVacuna.UltimaModificacion = new DateTime();
            RepositorioVacuna repoVacuna = new RepositorioVacuna();

            if (repoVacuna.Add(unaVacuna))
            {
                return RedirectToAction("Index", "Vacuna");
            }
            return View();
        }

    }
}