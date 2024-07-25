using EcosistemasMarinos.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.IEspecie
{
    public interface IListadoEspecie
    {
        IEnumerable<Especie> Listar();
        IEnumerable<Especie> Listar(string argumento);
        IEnumerable<Especie> Listar(string tipoConsulta, string argumento);
        IEnumerable<Ecosistema> Listar(string tipoConsulta, int? especieId);
        IEnumerable<Especie> Listar(decimal? pesoMinimo, decimal? pesoMaximo);
    }
}