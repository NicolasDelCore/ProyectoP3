using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.IAmenaza;
using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.IEcosistema;
using EcosistemasMarinos.LogicaNegocio.Entidades;
using EcosistemasMarinos.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.LogicaAplicacion.CasosUso.CUAmenaza
{
    public class CUListadoAmenaza : IListadoAmenaza
    {

        public IRepositorioAmenaza RepositorioAmenaza { get; set; }
        public CUListadoAmenaza(IRepositorioAmenaza repositorioAmenaza)
        {
            RepositorioAmenaza = repositorioAmenaza;
        }
        public IEnumerable<Amenaza> Listar()
        {
            return RepositorioAmenaza.FindAll();
        }

    }
}
