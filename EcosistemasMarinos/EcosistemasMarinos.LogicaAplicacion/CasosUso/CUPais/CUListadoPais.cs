using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.IEstadoConservacion;
using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.IPais;
using EcosistemasMarinos.LogicaNegocio.Entidades;
using EcosistemasMarinos.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.LogicaAplicacion.CasosUso.CUPais
{
    public class CUListadoPais : IListadoPais
    {

        public IRepositorioPais RepositorioPaises { get; set; }
        public CUListadoPais(IRepositorioPais repositorioPaises)
        {
            RepositorioPaises = repositorioPaises;
        }
        public IEnumerable<Pais> Listar()
        {
            return RepositorioPaises.FindAll();
        }


    }
}
