using EcosistemasMarinos.LogicaAplicacion.CasosUso.CUAmenaza;
using EcosistemasMarinos.LogicaAplicacion.CasosUso.CUEcosistema;
using EcosistemasMarinos.LogicaAplicacion.CasosUso.CUEstadoConservacion;
using EcosistemasMarinos.LogicaAplicacion.CasosUso.CULog;
using EcosistemasMarinos.LogicaAplicacion.CasosUso.CUPais;
using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.CUUsuario;
using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.IAmenaza;
using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.IEcosistema;
using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.IEspecie;
using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.IEstadoConservacion;
using EcosistemasMarinos.LogicaNegocio.Entidades;
using EcosistemasMarinos.LogicaNegocio.ValueObjects;
using EcosistemasMarinos.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Security.Claims;

namespace EcosistemasMarinos.MVC.Controllers
{
    public class EspecieController : Controller
    {
        public IAltaEspecie CUAltaEspecie { get; set; }
        public IListadoEspecie CUListadoEspecie { get; set; }
        public IListadoAmenaza CUListadoAmenaza { get; set; }
        public IListadoEstadoConservacion CUListadoEstadoConservacion { get; set; }
        public IListadoEcosistema CUListadoEcosistema { get; set; }
        public IWebHostEnvironment WHE { get; set; }
        public IBuscarEstadoConservacion CUBuscarEstadoConservacion { get; set; }
        public IListadoEcosistemasPorId CUListadoEcosistemasPorId { get; set; }
        public IListadoAmenazasPorId CUListadoAmenazasPorId { get; set; }
        public IBuscarEcosistemaPorId CUBuscarEcosistemaPorId { get; set; }
        public IBuscarEspeciePorId CUBuscarEspeciePorId { get; set; }
        public IVerificarEcosistema CUVerificarEcosistema { get; set; }
        public IVerificarUnicidadEspecie CUVerificarUnicidadEspecie { get; set; }
        public IVerificarAmenaza CUVerificarAmenaza { get; set; }
        public IEditarEcosistema CUEditarEcosistema { get; set; }
        public IEditarEspecie CUEditarEspecie { get; set; }
        public IAltaLog CUAltaLog { get; set; }

        //public IAsignarEcosistemaEspecie CUAsignarEcosistemaEspecie { get; set; }  

        //public IAsignarEspecieEcosistema CUAsignarEspecieEcosistema { get; set; }



        public EspecieController(IAltaEspecie cuAltaEspecie, IListadoEspecie cuListadoEspecie, IListadoAmenaza cuListadoAmenaza,
                IListadoEstadoConservacion cuListadoEstadoConservacion, IListadoEcosistema cuListadoEcosistema, IWebHostEnvironment whe,
                IBuscarEstadoConservacion cUBuscarEstadoConservacion, IListadoAmenazasPorId cUListadoAmenazasPorId, IListadoEcosistemasPorId cUListadoEcosistemasPorId,
                IBuscarEcosistemaPorId cUBuscarEcosistemaPorId, IBuscarEspeciePorId cuBuscarEspeciePorId, IVerificarEcosistema cUVerificarEcosistema,
                IVerificarUnicidadEspecie cUVerificarUnicidadEspecie, IVerificarAmenaza cUVerificarAmenaza, IEditarEcosistema cuEditarEcosistema, IEditarEspecie cuEditarEspecie, IAltaLog cuAltaLog)
        {
            CUAltaEspecie = cuAltaEspecie;
            CUListadoEspecie = cuListadoEspecie;
            CUListadoAmenaza = cuListadoAmenaza;
            CUListadoEstadoConservacion = cuListadoEstadoConservacion;
            CUListadoEcosistema = cuListadoEcosistema;
            WHE = whe;
            CUBuscarEstadoConservacion = cUBuscarEstadoConservacion;
            CUListadoAmenazasPorId = cUListadoAmenazasPorId;
            CUListadoEcosistemasPorId = cUListadoEcosistemasPorId;
            CUBuscarEcosistemaPorId = cUBuscarEcosistemaPorId;
            CUBuscarEspeciePorId = cuBuscarEspeciePorId;
            CUVerificarEcosistema = cUVerificarEcosistema;
            CUVerificarUnicidadEspecie = cUVerificarUnicidadEspecie;
            CUVerificarAmenaza = cUVerificarAmenaza;
            CUEditarEcosistema = cuEditarEcosistema;
            CUEditarEspecie = cuEditarEspecie;
            CUAltaLog = cuAltaLog;
        }

        // GET: EspecieController
        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<Especie> especiesTodo = CUListadoEspecie.Listar();
            return View(especiesTodo);
        }

        //Chicos, ¿porqué usaron un sólo CU para los listados en lugar de hacer varios CUs con toda la configuración que eso implica?
        //Profe, en nuestro afán de saber si podíamos, nunca nos detuvimos a preguntarnos si debíamos...
        [HttpPost]
        public ActionResult Index(int? tipoArgumento, string? argumento, decimal? pesoMin, decimal? pesoMax)
        {
            if (tipoArgumento == 1)
            {
                try
                {
                    if (argumento == null) { throw new InvalidOperationException("El nombre de la especie no puede ser nulo."); }
                    IEnumerable<Especie> especieNombreC = CUListadoEspecie.Listar("nombreCientifico", argumento);
                    if (especieNombreC.Count() == 0) { TempData["Mensaje"] = "No se encontraron especies que contengan ese término en su nombre." ; }
                    return View(especieNombreC);
                } catch (Exception ex)
                {
                    TempData["Mensaje"] = "Error: " + ex.Message; ;
                    return RedirectToAction("FiltroDefault");
                }
            }

            if (tipoArgumento == 2)
            {
                try
                {
                    IEnumerable<Especie> especiesEnPeligro = CUListadoEspecie.Listar("filtrarEspeciesenPeligro");
                    return View(especiesEnPeligro);
                }
                catch (Exception ex)
                {
                    TempData["Mensaje"] = "Error: " + ex.Message; ;
                    return RedirectToAction("FiltroDefault");
                }
            }

            else if (tipoArgumento == 3)
            {
                try
                {
                    if (pesoMin > pesoMax || pesoMin < 0.01M || pesoMax < 0.01M) {
                        ViewBag.Mensaje = "Error: Peso Mínimo no puede ser menor a Peso Máximo y ambos deben ser mayores a 0.01";
                        IEnumerable<Especie> especiesTodo = CUListadoEspecie.Listar(pesoMin, pesoMax);
                        return View(especiesTodo);
                    } else
                    {
                        IEnumerable<Especie> especiesTodo = CUListadoEspecie.Listar(pesoMin, pesoMax);
                        return View(especiesTodo);
                    }
                } catch (Exception ex)
                {
                    TempData["Mensaje"] = ex.Message;
                    return RedirectToAction("FiltroDefault");
                }
            }

            else {
                return RedirectToAction("FiltroDefault"); 
            }
        }

        public ActionResult FiltroDefault() {
            return RedirectToAction("Index", new { id = 0 }); //Este ID 0, es lo mismo que hacer tipoArgumento = 1, osea, este Else básicamente retorna el primer if (vista Index con el filtrado de todas las especies por defecto)
        }

        // GET: EspecieController/Create
        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            IEnumerable<Ecosistema> ecosistemas = CUListadoEcosistema.Listar();
            IEnumerable<Amenaza> amenazas = CUListadoAmenaza.Listar();
            IEnumerable<EstadoConservacion> estadoConservacion = CUListadoEstadoConservacion.Listar();
            EspecieViewModel especieViewModel = new EspecieViewModel()
            {
                Especie = new Especie(),
                Amenazas = amenazas,
                EstadosConservacion = estadoConservacion,
                Ecosistemas = ecosistemas
            };
            return View(especieViewModel);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EspecieViewModel especieViewModel)
        {

            try
            {
                var estadoConservacion = CUBuscarEstadoConservacion.BuscarEstadoConservacion(especieViewModel.IdEstadoConservacionSeleccionado);
                especieViewModel.Especie.EstadoConservacion = estadoConservacion;
                IEnumerable<Amenaza> amenazas = CUListadoAmenazasPorId.ListarAmenazasPorId(especieViewModel.IdAmenazasSeleccionada);
                especieViewModel.Especie.Amenazas = amenazas;
                especieViewModel.EstadosConservacion = CUListadoEstadoConservacion.Listar();
                especieViewModel.Amenazas = CUListadoAmenaza.Listar();
                especieViewModel.Ecosistemas = CUListadoEcosistema.Listar();
                List<Ecosistema> ecosistemas = CUListadoEcosistemasPorId.ListarEcosistemasPorId(especieViewModel.IdEcosistemasSeleccionados);
                especieViewModel.Especie.EcosistemasQuePuedenHabitar = ecosistemas;

                FileInfo fi = new FileInfo(especieViewModel.Imagen.FileName);
                string ext = fi.Extension;
                if (ext == ".png" || ext == ".jpg")
                {
                    string nombreArchivo = especieViewModel.Especie.NombreCientifico + ext;
                    especieViewModel.Especie.Imagen = nombreArchivo;
                    CUAltaEspecie.Alta(especieViewModel.Especie);
                    string directorioRaiz = WHE.WebRootPath;
                    string rutaCompleta = Path.Combine(directorioRaiz, "imgs", nombreArchivo);
                    FileStream fs = new FileStream(rutaCompleta, FileMode.Create);
                    especieViewModel.Imagen.CopyTo(fs);

                    string? username = User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();
                    if (username != null)
                    {
                        Log miLog = new Log(username, LogicaNegocio.Enums.Objetos.Especie, especieViewModel.Especie.Id, LogicaNegocio.Enums.Operaciones.Alta);
                        CUAltaLog.Alta(miLog);
                    }

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    throw new Exception("El tipo de imagen es inválido");
                }
            }

            catch (Exception ex)
            {

                ViewBag.Mensaje = ex.Message;
            }

            return View(especieViewModel);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Asign()
        {
            IEnumerable<Ecosistema> ecosistemas = CUListadoEcosistema.Listar();
            IEnumerable<Especie> especies = CUListadoEspecie.Listar();
            AsignViewModel asignViewModel = new AsignViewModel()
            {
                Ecosistemas = ecosistemas,
                Especies = especies
            };
            return View(asignViewModel);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Asign(int idEcosistema, int idEspecie)
        {
            Ecosistema ecosistema = CUBuscarEcosistemaPorId.Buscar(idEcosistema);
            Especie especie = CUBuscarEspeciePorId.Buscar(idEspecie);

            //construcción del viewmodel
            IEnumerable<Ecosistema> ecosistemas = CUListadoEcosistema.Listar();
            IEnumerable<Especie> especies = CUListadoEspecie.Listar();
            AsignViewModel asignViewModel = new AsignViewModel()
            {
                Ecosistemas = ecosistemas,
                Especies = especies
            };

            bool ecosistemaPermitido = CUVerificarEcosistema.Verificar(especie, ecosistema);
            bool especieYaExiste = CUVerificarUnicidadEspecie.VerificarUnicidad(especie, ecosistema);
            bool tienenLasMismasAmenazas = CUVerificarAmenaza.VerificarAmenaza(especie, ecosistema);
            bool nivelDeConservacionAdecuado = ecosistema.EstadoConservacion.EstadoPorcentual >= especie.EstadoConservacion.EstadoPorcentual;

            if (!ecosistemaPermitido || especieYaExiste || !nivelDeConservacionAdecuado || tienenLasMismasAmenazas)
            {
                if (!ecosistemaPermitido) { ViewBag.Mensaje = "Error: No se puede asociar esa especie y ese ecosistema.\n"; }
                if (especieYaExiste) { ViewBag.Mensaje += "Error: Esa especie y ese ecosistema ya se encuentran asociados.\n"; }
                if (!ecosistemaPermitido || tienenLasMismasAmenazas) { ViewBag.Mensaje += "Error: Ese pobre animalito no sobrevivirá en ese ecosistema.\n"; }
                if (!nivelDeConservacionAdecuado) { ViewBag.Mensaje += $"Error: No se puede asociar esta especie con estado de conservación {especie.EstadoConservacion.EstadoPorcentual} a un ecosistema con estado de conservación {ecosistema.EstadoConservacion.EstadoPorcentual} porque dificultará la conservación de la especie.\n"; }
            }
            else
            {
                try
                {
                    if (ecosistema == null || especie == null) { throw new InvalidOperationException("Problema en la vista. Ecosistema o Especie son null."); }
                    //ACÁ VAN LAS VALIDACIONES. DENTRO DEL IF DE LAS MISMAS VA LO SIGUIENTE.
                    ecosistema.EspeciesQueHabitan.Add(especie);
                    especie.EcosistemasQueHabitan.Add(ecosistema);
                    //MODIFICO LA BD.
                    CUEditarEcosistema.Editar(ecosistema);
                    CUEditarEspecie.Editar(especie);
                    ViewBag.Mensaje = "Se completó la asignación de especie-ecosistema correctamente.";
                    //Log
                    string? username = User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();
                    if (username != null)
                    {
                        //Log modificación especie
                        Log miLogEsp = new Log(username, LogicaNegocio.Enums.Objetos.Especie, especie.Id, LogicaNegocio.Enums.Operaciones.Modificacion);
                        CUAltaLog.Alta(miLogEsp);
                        //Log modificación ecosistema
                        Log miLogEco = new Log(username, LogicaNegocio.Enums.Objetos.Ecosistema, ecosistema.Id, LogicaNegocio.Enums.Operaciones.Modificacion);
                        CUAltaLog.Alta(miLogEco);
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Mensaje = "Error: Ocurrió un problema asociando la especie al ecosistema.\n" + ex;
                    if (ex.InnerException != null)
                    {
                        ViewBag.Mensaje += ex.InnerException;
                    }
                }
            }

            return View(asignViewModel);
        }
    }
}