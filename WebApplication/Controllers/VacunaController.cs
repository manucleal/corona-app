using System;
using System.Web.Mvc;
using Repositorios;
using Dominio.EntidadesNegocio;
using WcfServicioCoronApp;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication.Controllers
{
    public class VacunaController : Controller
    {
        public ActionResult Index()
        {
            if ((string)Session["documento"] == null){
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
        public ActionResult Index(string tipoFiltro, string filtroText = "", int filtroNumber = 0)
        {
            ServicioVacunas serviciosVacunas = new ServicioVacunas();

            if (tipoFiltro != null && (filtroText != "" || filtroNumber >= 0))
            {
                switch (tipoFiltro)
                {
                    case "PorNombre":
                        ViewBag.Vacunas = serviciosVacunas.GetTodasLasVacunasPorNombre(filtroText);
                        break;
                    case "PorFaseAprob":
                        ViewBag.Vacunas = serviciosVacunas.GetTodasLasVacunasPorFaseAprob(filtroNumber);
                        break;
                    case "PorPaisLab":
                        ViewBag.Vacunas = serviciosVacunas.GetTodasLasVacunasPorPaisLab(filtroText);
                        break;
                    case "PorTipoVac":
                        ViewBag.Vacunas = serviciosVacunas.GetTodasLasVacunasPorTipoVac(filtroText);
                        break;
                    case "PorTopeInferior":
                        ViewBag.Vacunas = serviciosVacunas.GetTodasLasVacunasPorTopeInferior(filtroNumber);
                        break;
                    case "PorTopeSuperior":
                        ViewBag.Vacunas = serviciosVacunas.GetTodasLasVacunasPorTopeSuperior(filtroNumber);
                        break;
                    case "PorNombreLab":
                        ViewBag.Vacunas = serviciosVacunas.GetTodasLasVacunasPorNombreLab(filtroText);
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
            if ((string)Session["documento"] == null) {
                Session["documento"] = null;
                Session["nombre"] = null;
                return RedirectToAction("Login", "Usuario");
            }

            cargarFiltros();
            return View();
        }

        [HttpPost]
        public ActionResult Alta(Vacuna unaVacuna)
        {
            if (ModelState.IsValid)
            {
                unaVacuna.IdUsuario = (string)Session["documento"];
                RepositorioVacuna repoVacuna = new RepositorioVacuna();
                IEnumerable<Vacuna> vacunas = repoVacuna.FindAllByName(unaVacuna.Nombre);
                if (vacunas.ToList().Count == 0)
                {
                    if (unaVacuna.MinTemp <= unaVacuna.MaxTemp)
                    {
                        if (repoVacuna.Add(unaVacuna))
                        {
                            return RedirectToAction("Index", "Vacuna");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("minTemp", "Debe ser menor o igual a Máxima temp.");
                    }
                } else
                {
                    ModelState.AddModelError("nombre", "Ya existe una vacuna con ese nombre");
                }
            }
            cargarFiltros();
            return View();
        }

        public void cargarFiltros()
        {
            RepositorioLaboratorio repoLaboratorio = new RepositorioLaboratorio();
            ViewBag.Laboratorios = repoLaboratorio.FindAll();
            RepositorioTipoVacuna repoTipoVacuna = new RepositorioTipoVacuna();
            ViewBag.TipoVacunas = repoTipoVacuna.FindAll();
        }
    }
}