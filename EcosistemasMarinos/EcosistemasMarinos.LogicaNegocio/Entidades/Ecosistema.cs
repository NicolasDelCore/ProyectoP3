using EcosistemasMarinos.LogicaNegocio.ExcepcionesEntidades;
using EcosistemasMarinos.LogicaNegocio.InterfacesEntidades;
using EcosistemasMarinos.LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.LogicaNegocio.Entidades
{
	public class Ecosistema : IValidable<Ecosistema>
	{

		/* ESTA ES LA FORMA DE PONER UN VALUE OBJECT */
		//public NombreEcosistema Nombre { get; set; }

		public int Id { get; set; }
		public string Nombre { get; set; }
		public Ubicacion Ubicacion { get; set; }
		public double Area { get; set; }
		public string Descripcion { get; set; }
		public List<Especie> EspeciesQueHabitan { get; set; }
        public List<Especie> EspeciesQuePuedenHabitar { get; set; }
        public List<Amenaza> Amenazas { get; set; }
		public Pais Pais { get; set; }
		public EstadoConservacion EstadoConservacion { get; set; }
		public string Imagen { get; set; }

		public Ecosistema()
		{


		}

		public Ecosistema(string nombre, Ubicacion ubicacion, double area, string descripcion, List<Especie> especies, Pais pais, List<Amenaza> amenazas, EstadoConservacion estadoConservacion)
		{
			Nombre = nombre;
			Ubicacion = ubicacion;
			Area = area;
			Descripcion = descripcion;
			EspeciesQuePuedenHabitar = especies;
			Pais = pais;
			Amenazas = amenazas;
			EstadoConservacion = estadoConservacion;
			
		}



		public void Validar()
		{
			if (string.IsNullOrEmpty(Nombre))
			{
				throw new EcosistemaException("No se ha proporcionado un nombre");
			}
			if(Ubicacion == null)
			{
				throw new EcosistemaException("No se ha proporcionado una ubicación");
			}
			if(Area < 0)
			{
				throw new EcosistemaException("No se ha proporcionado un área");
			}
			if (string.IsNullOrEmpty(Descripcion))
			{
				throw new EcosistemaException("No se ha proporcionado una descripción");
			}
			if(Pais == null)
			{
				throw new EcosistemaException("No se ha seleccionado un país");
			}
			if(EstadoConservacion == null)
			{
				throw new EcosistemaException("No se ha seleccionado un estado de conservación");
			}
		}
	}
}
