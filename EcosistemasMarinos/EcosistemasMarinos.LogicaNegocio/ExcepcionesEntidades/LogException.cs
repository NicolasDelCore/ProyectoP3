using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.LogicaNegocio.ExcepcionesEntidades
{
    public class LogException : Exception
    {
        public LogException() : base() { }

        public LogException(string msg) : base(msg) { }

        public LogException(string msg, Exception interna) : base(msg, interna) { }

    }
}