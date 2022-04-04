using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApplicationCore.ModelResponse;
using ApplicationCore.ServiceData;
using SitioWeb.ViewModels;

namespace SitioWeb.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Autenticar(Usuario usuario)
        {
            WelcomeViewModel welcomeViewModel = new WelcomeViewModel();
            try
            {
                if (ModelState.IsValid)
                {
                    Usuario oUsuario = null;
                    IServiceUsuario serviceUsuario = new ServiceUsuario();
                    IServicePermiso servicePermiso = new ServicePermiso();
                    oUsuario = serviceUsuario.AutentificacionUsuario(usuario);
                    if (oUsuario != null)
                    {
                        welcomeViewModel.NombreUsuario = oUsuario.NombreUsuario;
                        welcomeViewModel.Rol = oUsuario.Rol;
                        welcomeViewModel.ListaPermisos = servicePermiso.ListaPermisosPorId((int)oUsuario.RolId);
                        TempData["WelcomeViewModel"] = welcomeViewModel;
                        return View("Welcome",welcomeViewModel);
                    }
                    else
                    {
                        TempData["Error"] = "Datos del usuario incorrectos.";
                        return View("Index", usuario);
                    }
                }
                else
                {
                    return View("Index", usuario);
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Ocurrió un error.";
                return View("Index", usuario);
            }
        }

        public ActionResult Welcome()
        {
            WelcomeViewModel welcomeViewModel = new WelcomeViewModel();
            welcomeViewModel = (WelcomeViewModel)TempData["WelcomeViewModel"];
            TempData.Keep();
            return View(welcomeViewModel);
        }
        public ActionResult Create()
        {
            try
            {
                IServiceRol serviceRol = new ServiceRol();
                CreateViewModel createViewModel = new CreateViewModel();
                createViewModel.ListaRoles = serviceRol.ListaRoles();
                return View(createViewModel);
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Save(CreateViewModel createViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    IServiceUsuario serviceUsuario = new ServiceUsuario();
                    Usuario usuario = new Usuario()
                    {
                        NombreUsuario = createViewModel.NombreUsuario,
                        ContrasennaUsuario = createViewModel.ContrasennaUsuario,
                        RolId = createViewModel.RolSeleccionado
                    };
                     Usuario oUsuario = serviceUsuario.RegistroUsuario(usuario);
                    if (oUsuario != null)
                    {
                        TempData["Completado"] = "Usuario guardado con éxito.";
                    }
                    else
                    {
                        TempData["Error"] = "Datos del usuario incorrectos.";
                    }
                    return RedirectToAction("Create");
                }
                else
                {
                    return View("Create", createViewModel);
                }

            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                // Pasar el Error a la página que lo muestra
                TempData["Message"] = ex.Message;
                TempData.Keep();
                return RedirectToAction("Default", "Error");
            }
        }
    }
}
