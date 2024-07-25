using EcosistemasMarinos.LogicaNegocio.ExcepcionesEntidades;
using EcosistemasMarinos.LogicaNegocio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.LogicaNegocio.Entidades
{
	public class Pais : IValidable<Pais>
	{
		public int Id { get; set; }
		public string? Nombre { get; set; }
		public string Alfa { get; set; }

		public Pais()
		{

		}

		/*public Pais(string nombre, string alfa)
		{
			Nombre = nombre;
			Alfa = alfa;
			// No necesitas asignar manualmente los valores de Id y UltimoId aquí.
		}*/

		public void Validar()
		{
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new PaisException("No se ha proporcionado un nombre");
            }
            if (string.IsNullOrEmpty(Alfa))
            {
                throw new PaisException("No se ha proporcionado un alfa");
            }
        }
	}
}
