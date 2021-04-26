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
            
            RepositorioLaboratorio repoLaboratorio = new RepositorioLaboratorio();
            ViewBag.Laboratorios = repoLaboratorio.FindAll();
            RepositorioTipoVacuna repoTipoVacuna = new RepositorioTipoVacuna();
            ViewBag.TipoVacunas = repoTipoVacuna.FindAll();

            return View();
        }

        [HttpPost]
        public ActionResult Alta(Vacuna unaVacuna)
        {
            RepositorioLaboratorio repoLaboratorio = new RepositorioLaboratorio();
            ViewBag.Laboratorios = new MultiSelectList(repoLaboratorio.FindAll(), "Id", "Nombre");

            if (ModelState.IsValid)
            {
                if (unaVacuna.MinTemp <= unaVacuna.MinTemp)
                {
                    unaVacuna.IdUsuario = (string)Session["documento"];
                    RepositorioVacuna repoVacuna = new RepositorioVacuna();

                    if (repoVacuna.Add(unaVacuna))
                    {
                        return RedirectToAction("Index", "Vacuna");
                    }
                }
                else
                {
                    ModelState.AddModelError("minTemp", "Debe ser menor o igual a Máxima temp.");
                }

            }

            return View();
        }

    }
}