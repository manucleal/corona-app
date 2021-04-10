using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class VacunaController : Controller
    {
        // GET: Vacuna
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Alta()
        {
            //if ((string)Session["rol"] == null || (string)Session["rol"] != "Administrador")
            //{
            //    return RedirectToAction("login", "usuario");
            //}
            //ViewBag.Clientes = Sistema.Instancia.Clientes;
            return View();
        }

        [HttpPost]
        public ActionResult Alta(string nombre, DateTime fechaComienzo, int duracionEstimadaDias, string clienteRut, int? montoInicial, int? sueldoHora, string tipo)
        {
            ViewBag.mensaje = "";
            //if ((string)Session["rol"] == null || (string)Session["rol"] != "Administrador")
            //{
            //    return RedirectToAction("login", "usuario");
            //}
            if (tipo == "Presupuestado")
            {
                //Cliente cliente = Sistema.Instancia.BuscarCliente(clienteRut);
                //if (Sistema.Instancia.AltaProyectoPresupuestado(nombre, fechaComienzo, duracionEstimadaDias, cliente, (int)montoInicial))
                //    ViewBag.mensaje = "Se ingreso correctamente!!";
                //else
                //    ViewBag.mensaje = "Los datos no son correctos";

            }
            else if (tipo == "Hora")
            {
                //Cliente cliente = Sistema.Instancia.BuscarCliente(clienteRut);
                //if (Sistema.Instancia.AltaProyectoHora(nombre, fechaComienzo, duracionEstimadaDias, cliente, (int)sueldoHora))
                //    ViewBag.mensaje = "Se ingreso correctamente!!";
                //else
                //    ViewBag.mensaje = "Los datos no son correctos";
            }
            //ViewBag.Clientes = Sistema.Instancia.Clientes;
            return View();
        }

    }
}