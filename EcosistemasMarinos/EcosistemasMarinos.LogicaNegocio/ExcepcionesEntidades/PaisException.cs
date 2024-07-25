using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.LogicaNegocio.ExcepcionesEntidades
{
    public class PaisException : Exception
    {
        public PaisException() : base() { }

        public PaisException(string msg) : base(msg) { }

        public PaisException(string msg, Exception interna) : base(msg, interna) { }

    }
}