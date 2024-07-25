using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.LogicaNegocio.ExcepcionesEntidades
{
    public class EstadoConservacionException : Exception
    {
        public EstadoConservacionException() : base() { }

        public EstadoConservacionException(string msg) : base(msg) { }

        public EstadoConservacionException(string msg, Exception interna) : base(msg, interna) { }

    }
}