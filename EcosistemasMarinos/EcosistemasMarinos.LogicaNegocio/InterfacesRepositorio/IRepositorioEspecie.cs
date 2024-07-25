using EcosistemasMarinos.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.LogicaNegocio.InterfacesRepositorio
{
	public interface IRepositorioEspecie : IRepositorio<Especie>
	{
		public bool Verificar(Especie especie, Ecosistema ecosistema);
		public bool VerificarAmenaza(Especie especie, Ecosistema ecosistema);
        public IEnumerable<Especie> FindByNombre(string nombre);
		public IEnumerable<Especie> filtrarEspeciesenPeligro();
        public IEnumerable<Especie> FiltrarEspeciesPorEcosistema(string argumento);
		public IEnumerable<Especie> FiltrarEspeciesPorRangoDePeso(decimal? pesoMinimo, decimal? pesoMaximo);
        public IEnumerable<Ecosistema> ObtenerEcosistemasNoHabitablesPorEspecie(int? especieId);
        public IEnumerable<Ecosistema> ObtenerEcosistemasHabitadosPorEspecie(int? especieId);
    }
}
