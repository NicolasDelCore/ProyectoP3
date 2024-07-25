using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.CUUsuario;
using EcosistemasMarinos.LogicaNegocio.Entidades;
using EcosistemasMarinos.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.IUsuario;

namespace EcosistemasMarinos.LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUBuscarUsuarioPorAlias : ICUBuscarUsuarioPorAlias
    {
        #region DI
        public IRepositorioUsuario RepoUsuarios { get; set; }

        public CUBuscarUsuarioPorAlias(IRepositorioUsuario repo)
        {
            RepoUsuarios = repo;
        }
        #endregion

        #region Implementación
        public Usuario? BuscarPorAlias(string alias) {
            return RepoUsuarios.FindByAlias(alias);
        }
        #endregion
    }
}
