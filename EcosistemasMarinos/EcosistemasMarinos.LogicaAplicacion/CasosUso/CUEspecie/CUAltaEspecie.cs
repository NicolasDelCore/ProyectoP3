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
    public class CUAltaEspecie : IAltaEspecie
    {
        public IRepositorioEspecie RepositorioEspecies { get; set; }
        public CUAltaEspecie(IRepositorioEspecie repositorioEspecies)
        {
            RepositorioEspecies = repositorioEspecies;
        }

        public void Alta(Especie especie)
        {
            RepositorioEspecies.Add(especie);
        }
    }
}
