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
    public class CUListadoEstadoConservacion : IListadoEstadoConservacion
    {

        public IRepositorioEstadoConservacion RepositorioEstadoConservacion { get; set; }
        public CUListadoEstadoConservacion(IRepositorioEstadoConservacion repositorioEstadoConservacion)
        {
            RepositorioEstadoConservacion = repositorioEstadoConservacion;
        }
        public IEnumerable<EstadoConservacion> Listar()
        {
            return RepositorioEstadoConservacion.FindAll();
        }


    }
}
