using EcosistemasMarinos.LogicaAplicacion.CasosUso;
using EcosistemasMarinos.LogicaAplicacion.CasosUso.CUEcosistema;
using EcosistemasMarinos.LogicaAplicacion.CasosUso.CUEspecie;
using EcosistemasMarinos.LogicaAplicacion.CasosUso.CUPais;
using EcosistemasMarinos.LogicaAplicacion.CasosUso.CUUsuario;
using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.CUUsuario;
using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.IAmenaza;
using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.IEcosistema;
using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.IEspecie;
using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.IEstadoConservacion;
using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.IPais;
using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.IUsuario;
using EcosistemasMarinos.LogicaNegocio.Entidades;
using EcosistemasMarinos.LogicaNegocio.InterfacesRepositorio;
using EcosistemasMarinos.LogicaNegocio.ValueObjects;
using EcosistemasMarinos.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Security.Claims;

namespace EcosistemasMarinos.MVC.Controllers
{
    public class EcosistemaController : Controller
    {
        public IAltaEcosistema CUAltaEcosistema { get; set; } 
        public IListadoEcosistema CUListadoEcosistema { get; set; }
        public IBajaEcosistema CUBajaEcosistema { get; set; } 
        public IEditarEcosistema CUEditarEcosistema { get; set; }
        public IWebHostEnvironment WHE { get; set; } 
        public IListadoAmenaza CUListadoAmenaza { get; set; } 
        public IListadoPais CUListadoPais { get; set; } 
        public IBuscarPais CUBuscarPais { get; set; } 
        public IListadoEstadoConservacion CUListadoEstadoConservacion { get; set; } 
        public IBuscarEstadoConservacion CUBuscarEstadoConservacion { get; set; } 
        public IListadoAmenazasPorId CUListadoAmenazasPorId { get; set; } 
        public IBuscarEcosistemaPorId CUBuscarEcosistemaPorId { get; set; } 
        public IListadoEspecie CUListadoEcosistemaPorEspecie { get; set; }
        public IAltaLog CUAltaLog { get; set; }
        public IFindByNombreEcosistema CUEcosistemaFindByNombre;
        public ICUBuscarUsuarioPorAlias CUBuscarUsuarioPorAlias;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public EcosistemaController(IAltaEcosistema cuAltaEcosistema, IListadoEcosistema cuListadoEcosistema, IBajaEcosistema cuBajaEcosistema,
            IEditarEcosistema cuEditarEcosistema, IWebHostEnvironment whe, IListadoAmenaza cuListadoAmenazas, IListadoPais cuListadoPaises,
            IListadoEstadoConservacion cuListadoEstadosConservacion, IBuscarPais cuBuscarPais, IBuscarEstadoConservacion cuBuscarEstadoConservacion,
            IListadoAmenazasPorId cuListadoAmenazasPorId, IBuscarEcosistemaPorId cuBuscarEcosistemaPorId, IAltaLog cuAltaLog, ICUBuscarUsuarioPorAlias cuBuscarUsuarioPorAlias, IFindByNombreEcosistema cuFindEcosistemaByNombre, IListadoEspecie cuListadoEcosistemaPorEspecie, IHttpContextAccessor httpContextAccessor)
        {
            CUAltaEcosistema = cuAltaEcosistema;
            CUListadoEcosistema = cuListadoEcosistema;
            CUBajaEcosistema = cuBajaEcosistema;
            CUEditarEcosistema = cuEditarEcosistema;
            WHE = whe;
            CUListadoAmenaza = cuListadoAmenazas;
            CUListadoPais = cuListadoPaises;
            CUListadoEstadoConservacion = cuListadoEstadosConservacion;
            CUBuscarPais = cuBuscarPais;
            CUBuscarEstadoConservacion = cuBuscarEstadoConservacion;
            CUListadoAmenazasPorId = cuListadoAmenazasPorId;
            CUBuscarEcosistemaPorId = cuBuscarEcosistemaPorId;
            CUAltaLog = cuAltaLog;
            CUEcosistemaFindByNombre = cuFindEcosistemaByNombre;
            CUBuscarUsuarioPorAlias = cuBuscarUsuarioPorAlias;
            CUListadoEcosistemaPorEspecie = cuListadoEcosistemaPorEspecie;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: EcosistemaController
        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<Ecosistema> ecosistemas = CUListadoEcosistema.Listar();
            return View(ecosistemas);
        }
        [HttpPost]
        public ActionResult Index(int? tipoArgumento, int? argumento)
        {
            
            if (tipoArgumento == 1)
            {
                try
                {
                    if (argumento == null || argumento < 0) { throw new InvalidOperationException("Id no válido. Puede revisar los IDs en Especies."); }
                    IEnumerable<Ecosistema> especiesPorEcosistema = CUListadoEcosistemaPorEspecie.Listar("ObtenerEcosistemasHabitadosPorEspecie", argumento);
                    if (especiesPorEcosistema.Count() == 0) { TempData["Mensaje"] = "Error: No se encontraron ecosistemas asociados a una especie con ese ID."; }
                    return View(especiesPorEcosistema);
                }
                catch (Exception ex)
                {
                    TempData["Mensaje"] = "Error: " + ex.Message;
                    return RedirectToAction("Index", "Ecosistema");
                }
            }

            if (tipoArgumento == 2)
            {
                try
                {
                    if (argumento == null || argumento < 0) { throw new InvalidOperationException("Id no válido. Puede revisar los IDs en Especies."); }
                    IEnumerable<Ecosistema> especiesPorEcosistema = CUListadoEcosistemaPorEspecie.Listar("ObtenerEcosistemasNoHabitablesPorEspecie", argumento);
                    //if (especiesPorEcosistema.Count() == 0) { TempData["Mensaje"] = "No se encontraron ecosistemas asociados a una especie con ese ID."; }
                    return View(especiesPorEcosistema);
                }
                catch (Exception ex)
                {
                    TempData["Mensaje"] = "Error: " + ex.Message;
                    return RedirectToAction("Index", "Ecosistema");
                }
            }


            else
            {
                return RedirectToAction("Index", "Ecosistema");
            }
        }

        // GET: EcosistemaController/Create
        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            IEnumerable<Pais> paises = CUListadoPais.Listar();
            IEnumerable<Amenaza> amenazas = CUListadoAmenaza.Listar();
            IEnumerable<EstadoConservacion> estadoConservacion = CUListadoEstadoConservacion.Listar();
            EcosistemaViewModel ecosistemaViewModel = new EcosistemaViewModel()
            {
                Ecosistema = new Ecosistema(),
                Paises = paises,
                Amenazas = amenazas,
                EstadosConservacion = estadoConservacion
            };


            return View(ecosistemaViewModel);
        }

        // POST: EcosistemaController/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EcosistemaViewModel ecosistemaViewModel)
        {
            try
            {
                var pais = CUBuscarPais.BuscarPais(ecosistemaViewModel.IdPaisSeleccionado);
                ecosistemaViewModel.Ecosistema.Pais = pais;
                var estadoConservacion = CUBuscarEstadoConservacion.BuscarEstadoConservacion(ecosistemaViewModel.IdEstadoConservacionSeleccionado);
                ecosistemaViewModel.Ecosistema.EstadoConservacion = estadoConservacion;
                List<Amenaza> amenazas = CUListadoAmenazasPorId.ListarAmenazasPorId(ecosistemaViewModel.IdAmenazasSeleccionada);
                ecosistemaViewModel.Paises = CUListadoPais.Listar();
                ecosistemaViewModel.Amenazas = CUListadoAmenaza.Listar();
                ecosistemaViewModel.Ecosistema.Amenazas = amenazas;
                ecosistemaViewModel.EstadosConservacion = CUListadoEstadoConservacion.Listar();

                FileInfo fi = new FileInfo(ecosistemaViewModel.Imagen.FileName);
                string ext = fi.Extension;
                if (ext == ".png" || ext == ".jpg")
                {
                    string nombreArchivo = ecosistemaViewModel.Ecosistema.Nombre + ext;
                    ecosistemaViewModel.Ecosistema.Imagen = nombreArchivo;

                    //Ecosistema eco = CUEcosistemaFindByNombre.FindByNombre(ecosistemaViewModel.Ecosistema.Nombre);
                    CUAltaEcosistema.Alta(ecosistemaViewModel.Ecosistema);
                    string? username = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();
                    
                    if (username != null) {
                        Log miLog = new Log(username, LogicaNegocio.Enums.Objetos.Ecosistema, ecosistemaViewModel.Ecosistema.Id, LogicaNegocio.Enums.Operaciones.Alta);
                        CUAltaLog.Alta(miLog);
                    }

                    string directorioRaiz = WHE.WebRootPath;
                    string rutaCompleta = Path.Combine(directorioRaiz, "imgs", nombreArchivo);
                    FileStream fs = new FileStream(rutaCompleta, FileMode.Create);
                    ecosistemaViewModel.Imagen.CopyTo(fs);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    throw new Exception("El tipo de imagen no es válido");
                }

            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                if (ex.InnerException != null) {
                    ViewBag.Mensaje += " \n " + ex.InnerException; //Acá en vez de esto, por seguridad, deberíamos enviar la inner exception a algún tipo de log, porque podría exponer nombres de métodos y esas cosas
                }
            }
            return View(ecosistemaViewModel);
        }

        // GET: EcosistemaController/Edit/5
        public ActionResult Edit(int id) {
            return View();
        }

        // POST: EcosistemaController/Edit/5
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EcosistemaViewModel ecosistemaViewModel, Especie especie)
        {
            if (ModelState.IsValid)
            {
                var ecosistema = new Ecosistema();
                CUEditarEcosistema.Editar(ecosistema);

                string? username = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();

                if (username != null)
                {
                    Log miLog = new Log(username, LogicaNegocio.Enums.Objetos.Ecosistema, ecosistema.Id, LogicaNegocio.Enums.Operaciones.Modificacion);
                    CUAltaLog.Alta(miLog);
                }
            }
            // Si la validación del ViewModel falla, regresa a la vista de registro
            return View(ecosistemaViewModel);
        }

        // GET: EcosistemaController/Delete/5
        [HttpGet]
        [Authorize]
        public ActionResult Delete(int id)
        {
            Ecosistema ecosistema = CUBuscarEcosistemaPorId.Buscar(id);
            if (ecosistema == null) {
                ViewBag.Error = "El ecosistema con el id " + id + " noexiste";
            }
            return View(ecosistema);
        }

        // POST: EcosistemaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Delete(Ecosistema ecosistemaDelete)
        {
            try
            {
                Ecosistema ecosistema = CUBuscarEcosistemaPorId.Buscar(ecosistemaDelete.Id);
                CUBajaEcosistema.Baja(ecosistema);
                string? username = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();
                if (username != null) {
                    Log miLog = new Log(username, LogicaNegocio.Enums.Objetos.Ecosistema, ecosistema.Id, LogicaNegocio.Enums.Operaciones.Baja);
                    CUAltaLog.Alta(miLog);
                }
                return RedirectToAction(nameof(Index));
            } catch (Exception ex) {
                ViewBag.Mensaje = ex.Message;
                    if (ex.InnerException != null) {
                        ViewBag.Mensaje += " \n " + ex.InnerException; //Acá en vez de esto, por seguridad, deberíamos enviar la inner exception a algún tipo de log, porque podría exponer nombres de métodos y esas cosas
                    }
                return View(ecosistemaDelete);
            }
        }
    }
}
