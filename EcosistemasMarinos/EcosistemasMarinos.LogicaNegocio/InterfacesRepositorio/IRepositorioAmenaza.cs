using EcosistemasMarinos.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.LogicaNegocio.InterfacesRepositorio
{
	public interface IRepositorioAmenaza: IRepositorio<Amenaza>
	{
        public List<Amenaza> FindObjectsById(IEnumerable<int> ids);

    }
}
