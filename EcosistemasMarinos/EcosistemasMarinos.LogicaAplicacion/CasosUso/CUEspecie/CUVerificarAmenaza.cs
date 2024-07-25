using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.IEspecie;
using EcosistemasMarinos.LogicaNegocio.Entidades;
using EcosistemasMarinos.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.LogicaAplicacion.CasosUso.CUEspecie
{
    public class CUVerificarAmenaza : IVerificarAmenaza
    {
        public IRepositorioEspecie RepositorioEspecies { get; set; }
        public CUVerificarAmenaza(IRepositorioEspecie repositorioEspecies)
        {
            RepositorioEspecies = repositorioEspecies;
        }

        public bool VerificarAmenaza(Especie especie, Ecosistema ecosistema)
        {
            return RepositorioEspecies.VerificarAmenaza(especie, ecosistema);
        }
    }
}
