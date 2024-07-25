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
    public class CUModificarMaxCharDescripcion : IModificarMaxCharDescripcion
    {
        IRepositorioParametro RepositorioParametro { get; set; }

        public CUModificarMaxCharDescripcion(IRepositorioParametro repositorioParametro)
        {
            RepositorioParametro = repositorioParametro;
        }
        public void Modificar(int valorNuevo)
        {
            Parametro parametro = RepositorioParametro.BuscarParametroPorNombre("MaxCharDescripcion");
            parametro.Valor = valorNuevo.ToString();
            RepositorioParametro.Update(parametro);
            Especie.MaxCharDescripcion = valorNuevo;
        }
    }
}
