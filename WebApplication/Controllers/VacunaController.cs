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
            return View();
        }

        [HttpPost]
        public ActionResult Alta(Vacuna unaVacuna)
        {
            ViewBag.mensaje = "";

            unaVacuna.ProduccionAnual = 1000000;
            unaVacuna.UltimaModificacion = new DateTime();
            RepositorioVacuna repoVacuna = new RepositorioVacuna();
            bool result = repoVacuna.Add(unaVacuna);

            //if ((string)Session["rol"] == null || (string)Session["rol"] != "Administrador")
            //{
            //    return RedirectToAction("login", "usuario");
            //}
            //if (tipo == "Presupuestado")
            //{
            //    Cliente cliente = Sistema.Instancia.BuscarCliente(clienteRut);
            //    if (Sistema.Instancia.AltaProyectoPresupuestado(nombre, fechaComienzo, duracionEstimadaDias, cliente, (int)montoInicial))
            //        ViewBag.mensaje = "Se ingreso correctamente!!";
            //    else
            //        ViewBag.mensaje = "Los datos no son correctos";

            //}
            //else if (tipo == "Hora")
            //{
            //    Cliente cliente = Sistema.Instancia.BuscarCliente(clienteRut);
            //    if (Sistema.Instancia.AltaProyectoHora(nombre, fechaComienzo, duracionEstimadaDias, cliente, (int)sueldoHora))
            //        ViewBag.mensaje = "Se ingreso correctamente!!";
            //    else
            //        ViewBag.mensaje = "Los datos no son correctos";
            //}
            //ViewBag.Clientes = Sistema.Instancia.Clientes;
            return View();
        }

    }
}