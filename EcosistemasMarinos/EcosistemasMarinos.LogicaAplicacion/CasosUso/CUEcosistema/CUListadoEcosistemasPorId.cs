using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.IEcosistema;
using EcosistemasMarinos.LogicaNegocio.Entidades;
using EcosistemasMarinos.LogicaNegocio.InterfacesRepositorio;
using LogicaAccesoDatos.RepositorioEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.LogicaAplicacion.CasosUso.CUEcosistema
{
    public class CUListadoEcosistemasPorId : IListadoEcosistemasPorId
    {
        public IRepositorioEcosistema RepositorioEcosistema { get; set; }
        public CUListadoEcosistemasPorId(IRepositorioEcosistema repositorioEcosistema)
        {
            RepositorioEcosistema = repositorioEcosistema;
        }
        public List<Ecosistema> ListarEcosistemasPorId(IEnumerable<int> ids)
        {
            return RepositorioEcosistema.FindObjectsById(ids);
        }
    }
}
