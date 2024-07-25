using EcosistemasMarinos.LogicaAplicacion.CasosUso.CUAmenaza;
using EcosistemasMarinos.LogicaAplicacion.CasosUso.CUEcosistema;
using EcosistemasMarinos.LogicaAplicacion.CasosUso.CUEstadoConservacion;
using EcosistemasMarinos.LogicaAplicacion.CasosUso.CULog;
using EcosistemasMarinos.LogicaAplicacion.CasosUso.CUPais;
using EcosistemasMarinos.LogicaAplicacion.CasosUso.CUParametro;
using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.CUUsuario;
using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.IAmenaza;
using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.IEcosistema;
using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.IEstadoConservacion;
using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.IPais;
using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.IParametro;
using EcosistemasMarinos.LogicaNegocio.Entidades;
using EcosistemasMarinos.LogicaNegocio.Parametros;
using EcosistemasMarinos.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EcosistemasMarinos.MVC.Controllers
{
    [Authorize]
    public class ParametroController : Controller
    {

        public IModificarMinCharNombre CUModificarMinCharNombre { get; set; }
        public IModificarMaxCharNombre CUModificarMaxCharNombre { get; set; }
        public IModificarMinCharDescripcion CUModificarMinCharDescripcion { get; set; }
        public IModificarMaxCharDescripcion CUModificarMaxCharDescripcion { get; set; }
        public IListadoParametro CUListadoParametro { get; set; }
        public IBuscarParametroPorId CUBuscarParametroPorId { get; set; }
        public IAltaLog CUAltaLog { get; set; }


        public ParametroController(IModificarMinCharNombre cuModificarMinCharNombre, IModificarMaxCharNombre cuModificarMaxCharNombre,
            IModificarMinCharDescripcion cuModificarMinCharDescripcion, IModificarMaxCharDescripcion cuModificarMaxCharDescripcion, IListadoParametro cuListadoParametros,
            IBuscarParametroPorId cUBuscarParametroPorId, IAltaLog cuAltaLog)
        {
            CUModificarMinCharNombre = cuModificarMinCharNombre;
            CUModificarMaxCharNombre = cuModificarMaxCharNombre;
            CUModificarMinCharDescripcion = cuModificarMinCharDescripcion;
            CUModificarMaxCharDescripcion = cuModificarMaxCharDescripcion;
            CUListadoParametro = cuListadoParametros;
            CUBuscarParametroPorId = cUBuscarParametroPorId;
            CUAltaLog = cuAltaLog;
        }


        // GET: Parametro
        public ActionResult Index()
        {
            IEnumerable<Parametro> parametros = CUListadoParametro.Listar();
            return View(parametros);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            Parametro parametro = CUBuscarParametroPorId.Buscar(id);
            if (parametro == null)
            {
                ViewBag.Error = "El parametro con el id " + id + " no existe";
            }
            return View(parametro);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(int idParametro, int nuevoValor)
        {
            Parametro parametro = CUBuscarParametroPorId.Buscar(idParametro);
            try
            {
                if (parametro.Id == 1)
                {
                    CUModificarMinCharNombre.Modificar(nuevoValor);
                }
                else if (parametro.Id == 2)
                {
                    CUModificarMaxCharNombre.Modificar(nuevoValor);
                }
                else if (parametro.Id == 3)
                {
                    CUModificarMinCharDescripcion.Modificar(nuevoValor);
                }
                else if (parametro.Id == 4)
                {
                    CUModificarMaxCharDescripcion.Modificar(nuevoValor);
                }

                string? username = User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();
                if (username != null)
                {
                    Log miLog = new Log(username, LogicaNegocio.Enums.Objetos.Parametro, idParametro, LogicaNegocio.Enums.Operaciones.Modificacion);
                    CUAltaLog.Alta(miLog);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
