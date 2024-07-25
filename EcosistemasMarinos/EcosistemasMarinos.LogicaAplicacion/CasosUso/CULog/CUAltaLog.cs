using EcosistemasMarinos.LogicaAccesoDatos.RepositorioEF;
using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.CUUsuario;
using EcosistemasMarinos.LogicaNegocio.Entidades;
using EcosistemasMarinos.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.LogicaAplicacion.CasosUso.CULog
{
    public class CUAltaLog : IAltaLog
    {
        public IRepositorio<Log> RepositorioLog { get; set; }

        public CUAltaLog(IRepositorio<Log> repositorioLog)
        {
            RepositorioLog = repositorioLog;
        }
        public void Alta(Log obj)
        {
            RepositorioLog.Add(obj);
        }
    }
}
