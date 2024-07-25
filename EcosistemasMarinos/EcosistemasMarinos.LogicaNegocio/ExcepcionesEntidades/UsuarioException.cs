using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.LogicaNegocio.ExcepcionesEntidades
{
    public class UsuarioException : Exception
    {
        public UsuarioException() : base() { }

        public UsuarioException(string msg) : base(msg) { }

        public UsuarioException(string msg, Exception interna) : base(msg, interna) { }

    }
}