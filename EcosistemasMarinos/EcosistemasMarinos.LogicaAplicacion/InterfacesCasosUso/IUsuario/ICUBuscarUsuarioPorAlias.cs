using EcosistemasMarinos.LogicaNegocio.Entidades;
using EcosistemasMarinos.LogicaNegocio.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.IUsuario
{
    public interface ICUBuscarUsuarioPorAlias { 
        Usuario? BuscarPorAlias(string alias);
    }
}
