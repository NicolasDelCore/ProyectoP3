using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.IEcosistema;
using EcosistemasMarinos.LogicaNegocio.Entidades;
using EcosistemasMarinos.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.LogicaAplicacion.CasosUso.CUEcosistema
{
    public class CUVerificarUnicidadEspecie:IVerificarUnicidadEspecie
    {
        public IRepositorioEcosistema RepositorioEcosistema { get; set; }

        public CUVerificarUnicidadEspecie(IRepositorioEcosistema repositorioEcosistema)
        {
            RepositorioEcosistema = repositorioEcosistema;
        }

        public bool VerificarUnicidad(Especie especie, Ecosistema ecosistema)
        {
           return RepositorioEcosistema.VerificarUnicidadEspecie(especie, ecosistema);
        }
    }
}
