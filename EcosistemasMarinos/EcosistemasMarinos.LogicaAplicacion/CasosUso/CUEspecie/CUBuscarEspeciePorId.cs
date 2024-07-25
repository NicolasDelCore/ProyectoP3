
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
    public class CUBuscarEspeciePorId : IBuscarEspeciePorId
    {
        public IRepositorioEspecie RepositorioEspecies { get; set; }
        public CUBuscarEspeciePorId(IRepositorioEspecie repositorioEspecies)
        {
            RepositorioEspecies = repositorioEspecies;
        }

        public Especie Buscar(int idEspecie)
        {
            return RepositorioEspecies.FindById(idEspecie);
        }
    }
}
