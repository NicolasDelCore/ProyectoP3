using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.IParametro;
using EcosistemasMarinos.LogicaNegocio.Entidades;
using EcosistemasMarinos.LogicaNegocio.InterfacesRepositorio;
using EcosistemasMarinos.LogicaNegocio.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.LogicaAplicacion.CasosUso.CUParametro
{
    public class CUListadoParametro : IListadoParametro
    {
        IRepositorioParametro RepositorioParametro { get; set; }

        public CUListadoParametro(IRepositorioParametro repositorioParametro)
        {
            RepositorioParametro = repositorioParametro;
        }

        public IEnumerable<Parametro> Listar()
        {
            return RepositorioParametro.FindAll();
        }
    }
}
