using System.Web.Mvc;
using Dominio.EntidadesNegocio;
using Repositorios;

namespace WebApplication.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Registro()
        {
            return View("Registro");
        }

        [HttpPost]
        public ActionResult Registro(Usuario unUsuario)
        {
            if (unUsuario.Documento.Length == 8 && unUsuario.Nombre.Length >= 6)
            {
                //TO DO validar password (una mayuscula, una minuscula, un numero como minimo)
                RepositorioUsuario repoUsuario = new RepositorioUsuario();
                Usuario usuario = repoUsuario.FindById(unUsuario.Documento);

                if (usuario.Documento != null)
                {
                    ViewBag.Mensaje = "El Usuario ya existe";
                }
                else
                {
                    if (repoUsuario.Add(unUsuario))
                    {
                        Session["documento"] = unUsuario.Documento;
                        Session["nombre"] = unUsuario.Nombre;
                        ViewBag.Mensaje = "El usuario se registró correctamente";
                        return RedirectToAction("index", "vacuna");
                    }
                }
            }
            else
            {
                ViewBag.Mensaje = "Los campos ingresados no son correctos";
            }
            return View("Registro");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario unUsuario) { 

            RepositorioUsuario repoUsuario = new RepositorioUsuario();
            
            if (repoUsuario.Login(unUsuario))
            {
                Session["documento"] = unUsuario.Documento;
                Session["nombre"] = unUsuario.Nombre;

                return RedirectToAction("index", "vacuna");
            }

            return View();
        }

        public ActionResult Salir()
        {
            Session["documento"] = null;
            Session["nombre"] = null;
            return RedirectToAction("login");
        }
    }
}