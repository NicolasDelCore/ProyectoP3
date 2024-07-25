using EcosistemasMarinos.LogicaAplicacion.CasosUso.CUAmenaza;
using EcosistemasMarinos.LogicaAplicacion.CasosUso.CUEstadoConservacion;
using EcosistemasMarinos.LogicaAplicacion.CasosUso.CUPais;
using EcosistemasMarinos.LogicaAplicacion.CasosUso.CUUsuario;
using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.CUUsuario;
using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.IUsuario;
using EcosistemasMarinos.LogicaNegocio.Entidades;
using EcosistemasMarinos.LogicaNegocio.Enums;
using EcosistemasMarinos.LogicaNegocio.ExcepcionesEntidades;
using EcosistemasMarinos.LogicaNegocio.Parametros;
using EcosistemasMarinos.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace EcosistemasMarinos.MVC.Controllers
{
    public class UsuarioController : Controller
    {

        public IAltaUsuario CUAltaUsuario { get; set; }
        public IAltaLog CUAltaLog { get; set; }

        public UsuarioController(IAltaUsuario cuAlta, IAltaLog cuAltaLog)
        {
            CUAltaUsuario = cuAlta;
            CUAltaLog = cuAltaLog;
        }


        // GET: UsuarioController/Create
        [HttpGet]
        [Authorize(Roles = nameof(Roles.Admin))]
        public ActionResult Create()
        {
            UsuarioRegistroViewModel usuarioViewModel = new UsuarioRegistroViewModel();
            return View(usuarioViewModel);
        }


        // POST: UsuarioController/Create
        [HttpPost]
        [Authorize(Roles = nameof(Roles.Admin))]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioRegistroViewModel usuarioViewModel)
        {

            if (ModelState.IsValid)
            {
                var usuario = new Usuario(usuarioViewModel.Alias, usuarioViewModel.Password, usuarioViewModel.Rol);
                try
                {
                    CUAltaUsuario.Alta(usuario);
                    ViewBag.Mensaje = $"Usuario {usuarioViewModel.Alias} creado exitosamente.";

                    string? username = User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();
                    if (username != null)
                    {
                        Log miLog = new Log(username, LogicaNegocio.Enums.Objetos.Usuario, usuario.Id, LogicaNegocio.Enums.Operaciones.Alta);
                        CUAltaLog.Alta(miLog);
                    }

                    return View(usuarioViewModel);
                }
                catch (UsuarioException ex)
                { //Excepciones de validación de usuario o controller
                    ViewBag.Mensaje = ex.Message;
                    if (ex.InnerException != null) { ViewBag.Mensaje += " " + ex.InnerException; }
                }
                catch (InvalidOperationException ex) //Excepciones de repo
                {
                    ViewBag.Mensaje = ex.Message;
                    if (ex.InnerException != null) { ViewBag.Mensaje += " " + ex.InnerException; }
                }
                catch (Exception ex) //otras excepciones
                {
                    ViewBag.Mensaje = ex.Message;
                    if (ex.InnerException != null) { ViewBag.Mensaje += " " + ex.InnerException; }
                }
            }

            // Si la validación del ViewModel falla, regresa a la vista de registro
            return View(usuarioViewModel);
        }
    }
}
