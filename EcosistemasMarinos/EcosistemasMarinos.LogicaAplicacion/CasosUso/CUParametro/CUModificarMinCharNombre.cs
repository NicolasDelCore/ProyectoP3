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
    public class CUModificarMinCharNombre : IModificarMinCharNombre
    {
        IRepositorioParametro RepositorioParametro { get; set; }

        public CUModificarMinCharNombre(IRepositorioParametro repositorioParametro)
        {
            RepositorioParametro = repositorioParametro;
        }
        public void Modificar(int valorNuevo)
        {
            Parametro parametro = RepositorioParametro.BuscarParametroPorNombre("MinCharNombre");
            parametro.Valor = valorNuevo.ToString();
            RepositorioParametro.Update(parametro);
            Especie.MinCharNombre = valorNuevo;
        }
    }
}
