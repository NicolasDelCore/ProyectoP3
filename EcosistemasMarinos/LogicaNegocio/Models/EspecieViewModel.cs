using EcosistemasMarinos.LogicaNegocio.Entidades;

namespace EcosistemasMarinos.MVC.Models
{
	public class EspecieViewModel
	{
		public Especie Especie { get; set; }
        public IEnumerable<Amenaza> Amenazas { get; set; }
        public IEnumerable<EstadoConservacion> EstadosConservacion { get; set; }
        public IEnumerable<Ecosistema> Ecosistemas { get; set; }

        public List<int> IdEcosistemasSeleccionados { get; set; }

        public List<int> IdAmenazasSeleccionada { get; set; }

        public int IdEstadoConservacionSeleccionado { get; set; }
        public IFormFile Imagen { get; set; }
	}
}
