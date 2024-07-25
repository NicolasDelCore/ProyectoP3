using EcosistemasMarinos.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.LogicaNegocio.InterfacesRepositorio
{
	public interface IRepositorioEcosistema : IRepositorio<Ecosistema>
	{
        public List<Ecosistema> FindObjectsById(IEnumerable<int> id);
        public bool VerificarUnicidadEspecie(Especie especie, Ecosistema ecosistema);
        public Ecosistema? FindByNombre(string nombre);

    }
}
