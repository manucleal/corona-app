using System;
using System.Web.Mvc;
using Repositorios;
using Dominio.EntidadesNegocio;
using WcfServicioCoronApp;
using System.Collections.Generic;

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

            ServicioVacunas serviciosVacunas = new ServicioVacunas();
            IEnumerable<DtoVacunas> vacunas = serviciosVacunas.GetTodasLasVacunas();
            if (vacunas != null)
            {
                ViewBag.Vacunas = vacunas;
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(string tipoFiltro, string filtro)
        {
            ServicioVacunas serviciosVacunas = new ServicioVacunas();

            if (tipoFiltro != null && filtro != null)
            {
                switch (tipoFiltro)
                {
                    case "PorNombre":
                        ViewBag.Vacunas = serviciosVacunas.GetTodasLasVacunasPorNombre(filtro);
                        break;
                    case "PorFaseAprob":
                        ViewBag.Vacunas = serviciosVacunas.GetTodasLasVacunasPorFaseAprob(4);
                        break;
                    case "PorPaisLab":
                        ViewBag.Vacunas = serviciosVacunas.GetTodasLasVacunasPorPaisLab(filtro);
                        break;
                    case "PorTipoVac":
                        ViewBag.Vacunas = serviciosVacunas.GetTodasLasVacunasPorTipoVac(filtro);
                        break;
                    case "PorTopeInferior":
                        ViewBag.Vacunas = serviciosVacunas.GetTodasLasVacunasPorTopeInferior(23);
                        break;
                    case "PorTopeSuperior":
                        ViewBag.Vacunas = serviciosVacunas.GetTodasLasVacunasPorTopeSuperior(23);
                        break;
                    case "PorNombreLab":
                        ViewBag.Vacunas = serviciosVacunas.GetTodasLasVacunasPorNombreLab(filtro);
                        break;
                    default:
                        ViewBag.Vacunas = serviciosVacunas.GetTodasLasVacunas();
                        break;
                }
            }
            else
            {
                ViewBag.Vacunas = serviciosVacunas.GetTodasLasVacunas();
            }

            return View();
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