using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.LogicaNegocio.ExcepcionesEntidades
{
    public class EcosistemaException : Exception
    {
        public EcosistemaException() : base() { }

        public EcosistemaException(string msg) : base(msg) { }

        public EcosistemaException(string msg, Exception interna) : base(msg, interna) { }

    }
}