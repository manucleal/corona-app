using System.Web.Mvc;
using Dominio.EntidadesNegocio;
using Repositorios;

namespace WebApplication.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Registro()
        {
            if ((string)Session["documento"] != null && Session["nombre"] != null) {
                return RedirectToAction("Index", "Vacuna");
            }
            return View("Registro");
        }

        [HttpPost]
        public ActionResult Registro(Usuario unUsuario)
        {

            if (this.VerificoPass(unUsuario.Password))
            {
                RepositorioUsuario repoUsuario = new RepositorioUsuario();
                Usuario usuario = repoUsuario.FindById(unUsuario.Documento);

                if (usuario.Documento != null)
                {
                    ModelState.AddModelError("documento", "El documento ya está registrado");
                }
                else if (repoUsuario.Add(unUsuario))
                {
                    Session["documento"] = unUsuario.Documento;
                    Session["nombre"] = usuario.Nombre;
                    return RedirectToAction("Index", "Vacuna");
                }
                else
                {
                    View("Registro");
                }
            }
            else
            {
                ModelState.AddModelError("password", "Contraseña débil");
            }

            return View("Registro");
        }

        public ActionResult Login()
        {
            if ((string)Session["documento"] != null && (string)Session["nombre"] != null){
                return RedirectToAction("Index", "Vacuna");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario unUsuario)
        { 

            if (ModelState.IsValid)
            {
                if (this.VerificoPass(unUsuario.Password))
                {
                    RepositorioUsuario repoUsuario = new RepositorioUsuario();
                    Usuario usuario = repoUsuario.Login(unUsuario);

                    if (usuario.Documento != null)
                    {
                        Session["documento"] = usuario.Documento;
                        Session["nombre"] = usuario.Nombre;
                        return RedirectToAction("Index", "Vacuna");
                    }
                    else
                    {
                        ModelState.AddModelError("password", "Documento y/o contraseña incorrectos");
                    }
                }
                else
                {
                    ModelState.AddModelError("password", "Contraseña débil");
                }
            }

            return View();
        }

        public ActionResult Salir()
        {
            Session["documento"] = null;
            Session["nombre"] = null;
            return RedirectToAction("Login");
        }

        public bool VerificoPass(string password)
        {
            int contMay = 0;
            int contMin = 0;
            int contDig = 0;
            if (password.Length >= 6)
            {
                for (int i = 0; i < password.Length; i++)
                {
                    if (char.IsUpper(password[i]))
                    {
                        contMay++;
                    }
                    if (char.IsLower(password[i]))
                    {
                        contMin++;
                    }
                    if (char.IsNumber(password[i]))
                    {
                        contDig++;
                    }
                }
            }
            return (contMay > 0 && contMin > 0 && contDig > 0);
        }
    }
}