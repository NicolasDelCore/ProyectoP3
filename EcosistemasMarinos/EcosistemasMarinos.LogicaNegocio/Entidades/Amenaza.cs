using EcosistemasMarinos.LogicaNegocio.ExcepcionesEntidades;
using EcosistemasMarinos.LogicaNegocio.InterfacesEntidades;
using EcosistemasMarinos.LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EcosistemasMarinos.LogicaNegocio.Entidades
{
	public class Amenaza : IValidable<Amenaza>
	{
		public int Id { get; set; }

		public string Descripcion { get; set; }
		public int Grado { get; set; }

        /*public Amenaza(string nombre, string descripcion, int grado)
		{
			Nombre = nombre;
			Descripcion = descripcion;
			Grado = grado;
			// No necesitas asignar Id y UltimoId aquí, Entity Framework se encargará de eso.
		}*/

		public Amenaza()
		{
			
		}

		public void Validar()
		{
            if (string.IsNullOrEmpty(Descripcion))
            {
                throw new AmenazaException("No se ha proporcionado una descripción");
            }
            if (Grado < 0)
            {
                throw new AmenazaException("No se han proporcionado los grados");
            }
        }
	}
}
