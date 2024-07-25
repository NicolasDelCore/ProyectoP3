using EcosistemasMarinos.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.IEstadoConservacion
{
    public interface IBuscarEstadoConservacion
    {
        EstadoConservacion BuscarEstadoConservacion(int idEstadoConservacion);
    }
}
