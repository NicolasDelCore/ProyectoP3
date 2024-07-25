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
    public class CUBajaEcosistema : IBajaEcosistema
    {
        public IRepositorioEcosistema RepositorioEcosistema { get; set; }

        public CUBajaEcosistema(IRepositorioEcosistema repositorioEcosistema)
        {
            RepositorioEcosistema = repositorioEcosistema;
        }

        public void Baja(Ecosistema ecosistema)
        {
            RepositorioEcosistema.Delete(ecosistema);
        }
    }
}
