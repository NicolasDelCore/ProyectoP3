using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.IEspecie;
using EcosistemasMarinos.LogicaNegocio.Entidades;
using EcosistemasMarinos.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.LogicaAplicacion.CasosUso.CUEspecie
{
    public class CUVerificarEcosistema:IVerificarEcosistema
    {
        public IRepositorioEspecie RepositorioEspecies { get; set; }
        public CUVerificarEcosistema(IRepositorioEspecie repositorioEspecies)
        {
            RepositorioEspecies = repositorioEspecies;
        }

        public bool Verificar(Especie especie, Ecosistema ecosistema)
        {
            return RepositorioEspecies.Verificar(especie, ecosistema);
        }
    }
}
