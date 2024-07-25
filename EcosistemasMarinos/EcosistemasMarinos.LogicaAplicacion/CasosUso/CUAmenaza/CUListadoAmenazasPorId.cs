using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.IAmenaza;
using EcosistemasMarinos.LogicaNegocio.Entidades;
using EcosistemasMarinos.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.LogicaAplicacion.CasosUso.CUAmenaza
{
    public class CUListadoAmenazasPorId:IListadoAmenazasPorId
    {
        public IRepositorioAmenaza RepositorioAmenaza { get; set; }
        public CUListadoAmenazasPorId(IRepositorioAmenaza repositorioAmenaza)
        {
            RepositorioAmenaza = repositorioAmenaza;
        }
        
        public List<Amenaza> ListarAmenazasPorId(IEnumerable<int> ids)
        {
            return RepositorioAmenaza.FindObjectsById(ids);
        }
    }
}
