using EcosistemasMarinos.LogicaNegocio.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioParametro : IRepositorio<Parametro>
    {
        string BuscarValorPorNombre(string nombre);

        Parametro BuscarParametroPorNombre(string nombre);
    }
}
