using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.IParametro;
using EcosistemasMarinos.LogicaNegocio.InterfacesRepositorio;
using EcosistemasMarinos.LogicaNegocio.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.LogicaAplicacion.CasosUso.CUParametro
{
    public class CUBuscarParametroPorId:IBuscarParametroPorId
    {
        IRepositorioParametro RepositorioParametro { get; set; }

        public CUBuscarParametroPorId(IRepositorioParametro repositorioParametro)
        {
            RepositorioParametro = repositorioParametro;
        }

        public Parametro Buscar(int idParametro)
        {
            return RepositorioParametro.FindById(idParametro);
        }
    }
}
