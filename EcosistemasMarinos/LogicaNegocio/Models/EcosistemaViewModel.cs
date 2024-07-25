using EcosistemasMarinos.LogicaAplicacion.CasosUso.CUAmenaza;
using EcosistemasMarinos.LogicaAplicacion.CasosUso.CUEstadoConservacion;
using EcosistemasMarinos.LogicaAplicacion.CasosUso.CUPais;
using EcosistemasMarinos.LogicaNegocio.Entidades;
namespace EcosistemasMarinos.MVC.Models
{
    public class EcosistemaViewModel
    {
        public Ecosistema Ecosistema { get; set; }
        public IEnumerable<Pais> Paises { get; set; }
        public IEnumerable<Amenaza> Amenazas { get; set; }
        public IEnumerable<EstadoConservacion> EstadosConservacion { get; set; }

        public int IdPaisSeleccionado { get; set; }

        public List<int> IdAmenazasSeleccionada { get; set; }

        public int IdEstadoConservacionSeleccionado { get; set; }

        public IFormFile Imagen { get; set; }

        //TENGO QUE TENER 3 LISTAS Y 3 INTS PARA LOS ID's QUE SELECCIONE.
    }
}
