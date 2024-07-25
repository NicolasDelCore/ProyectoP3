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
    public class CUFindByNombre : IFindByNombreEcosistema {
        public IRepositorioEcosistema RepositorioEcosistema { get; set; }

        public CUFindByNombre(IRepositorioEcosistema repositorioEcosistema)
        {
            RepositorioEcosistema = repositorioEcosistema;
        }
        public Ecosistema? FindByNombre(string nombre)
        {
            return RepositorioEcosistema.FindByNombre(nombre);
        }
    }
}
