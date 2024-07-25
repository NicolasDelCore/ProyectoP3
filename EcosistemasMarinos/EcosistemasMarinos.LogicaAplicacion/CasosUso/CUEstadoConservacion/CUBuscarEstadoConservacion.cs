using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.IEstadoConservacion;
using EcosistemasMarinos.LogicaNegocio.Entidades;
using EcosistemasMarinos.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.LogicaAplicacion.CasosUso.CUEstadoConservacion
{
    public class CUBuscarEstadoConservacion : IBuscarEstadoConservacion
    {
        public IRepositorioEstadoConservacion RepositorioEstadosConservacion { get; set; }
        public CUBuscarEstadoConservacion(IRepositorioEstadoConservacion repositorioEstadosConservacion)
        {
            RepositorioEstadosConservacion = repositorioEstadosConservacion;
        }

        public EstadoConservacion BuscarEstadoConservacion(int idEstadoConservacion)
        {
            return RepositorioEstadosConservacion.FindById(idEstadoConservacion);
        }
    }
}
