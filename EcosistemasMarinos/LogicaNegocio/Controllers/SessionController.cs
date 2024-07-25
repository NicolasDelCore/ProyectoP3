using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.CUUsuario;
using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.IUsuario;
using EcosistemasMarinos.LogicaNegocio.Tools;
using EcosistemasMarinos.LogicaNegocio.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using EcosistemasMarinos.MVC.Models;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Text;
using System.Configuration;
using System.Security.Cryptography.Xml;
using NuGet.Protocol.Plugins;

namespace Presentacion.Controllers
{
    public class SessionController : Controller
    {
        #region DI Casos de Uso
        public IAltaUsuario CUAltaUsuario { get; set; }
        public ICUBuscarUsuarioPorAlias CUBuscarUsuarioPorAlias { get; set; }
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionController(IAltaUsuario cuAltaUsuario, ICUBuscarUsuarioPorAlias cuBuscarUsuarioPorAlias, IHttpContextAccessor httpContextAccessor) {
            CUAltaUsuario = cuAltaUsuario;
            CUBuscarUsuarioPorAlias = cuBuscarUsuarioPorAlias;
            _httpContextAccessor = httpContextAccessor;
            CrearAdmin(); //singleton admin user
        }
        #endregion

        [HttpGet]
        public IActionResult Forbidden()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UsuarioLoginViewModel login)
        {
            if (login.Alias.IsNullOrEmpty() || login.Password.IsNullOrEmpty()) {
                ViewBag.Error = "Debe ingresar usuario y contraseña.";
            } else {
                try
                {
                    Usuario? usuario = CUBuscarUsuarioPorAlias.BuscarPorAlias(login.Alias);

                    if (usuario == null)
                    {
                        ViewBag.Error = "Usuario o contraseña incorrectos.";
                    }
                    else
                    {
                        byte[] encryptedText = System.Convert.FromBase64String(usuario.PasswordEncriptado);
                        //plaintext = System.Text.Encoding.UTF8.GetString(base64Bytes);
                        if (Encriptador.DesencriptamientoAES(encryptedText, usuario.PasswordIV) == login.Password)
                        {
                            //Usuario logueado
                            ViewBag.Error = ""; //Limpiar errores

                            var claims = new List<Claim> {
                                new Claim(ClaimTypes.NameIdentifier, usuario.Alias), //guardamos username en cookie
                                new Claim(ClaimTypes.Role, usuario.Rol.ToString()) //guardamos rol en cookie
                            };

                            var claimsIdentity = new ClaimsIdentity(claims, "UsuarioLogueado");

                            await _httpContextAccessor.HttpContext
                                .SignInAsync("UsuarioLogueado",
                                    new ClaimsPrincipal(claimsIdentity),
                                    new AuthenticationProperties());

                            return RedirectToAction("Index","Home");
                        } else {
                            ViewBag.Error = "Usuario o contraseña incorrectos.";
                        }
                    }
                }
                //creo que este catch nunca debería correr.. debería saltar sólo si se llama directo al método FindUsuarioPorAlias con un string vacío, pero, por las dudas
                catch (InvalidOperationException) { ViewBag.Error = "Usuario o contraseña incorrectos."; }
                //catch para problemas con la DB (ej, connection string erróneo o si en producción no se llegara a la DB real)
                catch (Exception ex) { ViewBag.Error = "Error inesperado. Revise su conexión y reintente nuevamente en unos minutos." + ex; }
            }

            return View(login);
        }

        public async Task<IActionResult> Logout() {
            await _httpContextAccessor.HttpContext
            .SignOutAsync("UsuarioLogueado");
            return RedirectToAction("Index", "Home");
        }

        //crear admin singleton
        public void CrearAdmin() {
            Usuario? admin = CUBuscarUsuarioPorAlias.BuscarPorAlias("Admin1");
            if ( admin == null ) { 
                CUAltaUsuario.Alta(new Usuario("Admin1","Admin.12",EcosistemasMarinos.LogicaNegocio.Enums.Roles.Admin));
            }
        }
    }
}