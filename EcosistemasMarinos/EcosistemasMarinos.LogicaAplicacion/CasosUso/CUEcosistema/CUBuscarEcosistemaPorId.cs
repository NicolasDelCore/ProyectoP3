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
    public class CUBuscarEcosistemaPorId:IBuscarEcosistemaPorId
    {
        public IRepositorioEcosistema RepositorioEcosistema { get; set; }

        public CUBuscarEcosistemaPorId(IRepositorioEcosistema repositorioEcosistema)
        {
            RepositorioEcosistema = repositorioEcosistema;
        }

        public Ecosistema Buscar(int idEcosistema)
        {
            return RepositorioEcosistema.FindById(idEcosistema);
        }
    }
}
