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
    public class CUListadoEcosistema : IListadoEcosistema
    {

        public IRepositorioEcosistema RepositorioEcosistema { get; set; }
        public CUListadoEcosistema(IRepositorioEcosistema repositorioEcosistema)
        {
            RepositorioEcosistema = repositorioEcosistema;
        }
        public IEnumerable<Ecosistema> Listar()
        {
            return RepositorioEcosistema.FindAll();
        }
    }
}
