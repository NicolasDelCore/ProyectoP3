using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.CUUsuario;
using EcosistemasMarinos.LogicaNegocio.Entidades;
using EcosistemasMarinos.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUAltaUsuario : IAltaUsuario
    {
        public IRepositorioUsuario RepositorioUsuario { get; set; }

        public CUAltaUsuario(IRepositorioUsuario repositorioUsuario)
        {
            RepositorioUsuario = repositorioUsuario;
        }
        public void Alta(Usuario usuario)
        {
            RepositorioUsuario.Add(usuario);
        }
	}
}
