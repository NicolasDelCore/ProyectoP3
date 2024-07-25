using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.IEspecie;
using EcosistemasMarinos.LogicaNegocio.Entidades;
using EcosistemasMarinos.LogicaNegocio.InterfacesRepositorio;
using LogicaAccesoDatos.RepositorioEF;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.LogicaAplicacion.CasosUso.CUEspecie
{
    public class CUListadoEspecie : IListadoEspecie
    {
        public IRepositorioEspecie RepositorioEspecies { get; set; }
        public CUListadoEspecie(IRepositorioEspecie repositorioEspecies)
        {
            RepositorioEspecies = repositorioEspecies;
        }

        IEnumerable<Especie> IListadoEspecie.Listar()
        {
            return RepositorioEspecies.FindAll();
        }

        IEnumerable<Especie> IListadoEspecie.Listar(string tipoConsulta) {
            if (tipoConsulta == "filtrarEspeciesenPeligro") {
                return RepositorioEspecies.filtrarEspeciesenPeligro();
            }
            else { throw new ArgumentException("Tipo de Consulta inválida."); }
        }

        IEnumerable<Especie> IListadoEspecie.Listar(string tipoConsulta, string argumento)
        {
            if (tipoConsulta == "nombreCientifico") {
                return RepositorioEspecies.FindByNombre(argumento);

            } else if (tipoConsulta == "FiltrarEspeciesPorEcosistema") {
                return RepositorioEspecies.FiltrarEspeciesPorEcosistema(argumento);

            } else {
                throw new ArgumentException("Tipo de Consulta o Argumento inválido.");
            }
        }
        IEnumerable<Ecosistema> IListadoEspecie.Listar(string tipoConsulta, int? especieId)
        {
            if (especieId == null || especieId < 0) { throw new InvalidOperationException("Error: Id no válido. Puede revisar los IDs en Especies."); }

            if (tipoConsulta == "ObtenerEcosistemasNoHabitablesPorEspecie")
            {
                return RepositorioEspecies.ObtenerEcosistemasNoHabitablesPorEspecie(especieId);
            }

            if (tipoConsulta == "ObtenerEcosistemasHabitadosPorEspecie")
            {
                return RepositorioEspecies.ObtenerEcosistemasHabitadosPorEspecie(especieId);
            }

            else {
                throw new ArgumentException("Tipo de Consulta o Argumento inválido.");
            }
}

        IEnumerable<Especie> IListadoEspecie.Listar(decimal? pesoMinimo, decimal? pesoMaximo)
        {
            return RepositorioEspecies.FiltrarEspeciesPorRangoDePeso(pesoMinimo, pesoMaximo);
        }
    }
}

