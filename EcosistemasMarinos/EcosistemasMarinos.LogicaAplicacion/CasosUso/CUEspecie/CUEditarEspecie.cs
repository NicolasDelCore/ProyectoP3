using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.IEspecie;
using EcosistemasMarinos.LogicaNegocio.Entidades;
using EcosistemasMarinos.LogicaNegocio.InterfacesRepositorio;
using LogicaAccesoDatos.RepositorioEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.LogicaAplicacion.CasosUso.CUEspecie
{
    public class CUEditarEspecie:IEditarEspecie
    {
        public IRepositorioEspecie RepositorioEspecies { get; set; }
        public CUEditarEspecie(IRepositorioEspecie repositorioEspecies)
        {
            RepositorioEspecies = repositorioEspecies;
        }

        public void Editar(Especie especie)
        {
            RepositorioEspecies.Update(especie);
        }
    }
}
