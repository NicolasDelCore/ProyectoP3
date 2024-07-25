using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.IEcosistema;
using EcosistemasMarinos.LogicaNegocio.Entidades;
using EcosistemasMarinos.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.LogicaAplicacion.CasosUso.CUEcosistema
{
	public class CUEditarEcosistema : IEditarEcosistema
	{
		public IRepositorioEcosistema RepositorioEcosistema { get; set; }

		public CUEditarEcosistema(IRepositorioEcosistema repositorioEcosistema)
		{
			RepositorioEcosistema = repositorioEcosistema;
		}

		public void Editar(Ecosistema ecosistema)
		{
			RepositorioEcosistema.Update(ecosistema);
		}
	}
}

