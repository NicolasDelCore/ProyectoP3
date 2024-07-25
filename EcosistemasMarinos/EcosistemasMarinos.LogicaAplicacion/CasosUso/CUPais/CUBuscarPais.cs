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
    public class CUBuscarPais : IBuscarPais
    {

        public IRepositorioPais RepositorioPaises { get; set; }
        public CUBuscarPais(IRepositorioPais repositorioPaises)
        {
            RepositorioPaises = repositorioPaises;
        }
       
        public Pais BuscarPais(int idPais)
        {
          return RepositorioPaises.FindById(idPais);
        }
    }
}
