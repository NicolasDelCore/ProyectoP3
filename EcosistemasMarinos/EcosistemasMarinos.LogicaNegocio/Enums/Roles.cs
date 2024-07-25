using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.LogicaNegocio.Enums
{
    public enum Roles {
        Admin, //Crea usuarios y puede hacer cambios mediante las operaciones CRUD disponibles.
        Editor //No crea usuarios, pero puede hacer cambios mediante las operaciones CRUD disponibles.
        //Usuarios no logueados: Sólo pueden interactuar con la aplicación en modo sólo lectura (no pueden hacer cambios).
    }
}
