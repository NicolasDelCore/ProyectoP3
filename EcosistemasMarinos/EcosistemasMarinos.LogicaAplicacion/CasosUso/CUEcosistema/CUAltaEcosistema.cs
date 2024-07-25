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
    public class CUAltaEcosistema : IAltaEcosistema
    {
        public IRepositorioEcosistema RepositorioEcosistema { get; set; }

        public CUAltaEcosistema(IRepositorioEcosistema repositorioEcosistema)
        {
            RepositorioEcosistema = repositorioEcosistema;
        }
        public void Alta(Ecosistema ecosistema)
        {
            RepositorioEcosistema.Add(ecosistema);
        }
    }
}
