using EcosistemasMarinos.LogicaNegocio.InterfacesEntidades;
using EcosistemasMarinos.LogicaNegocio.ExcepcionesEntidades;
using EcosistemasMarinos.LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EcosistemasMarinos.LogicaNegocio.Entidades
{
    public class Especie : IValidable<Especie>
    {
        //------------------------------------------------------------- CAMBIAR ESTOS VALORES HARDCODEADOS ---------------------------------------------------------------------
        public static int MaxCharNombre { get; set; } = 30;
        public static int MinCharNombre { get; set; } = 1;
        public static int MaxCharDescripcion { get; set; } = 10;
        public static int MinCharDescripcion { get; set; } = 1;
        public int Id { get; set; }
        public string NombreCientifico { get; set; }
        public string NombreVulgar { get; set; }
        public string Descripcion { get; set; }
        public RangoTamano RangoTamano { get; set; }

        [InverseProperty("EspeciesQueHabitan")]
        public List<Ecosistema> EcosistemasQueHabitan { get; set; }

        [InverseProperty("EspeciesQuePuedenHabitar")]
        public List<Ecosistema> EcosistemasQuePuedenHabitar { get; set; }
        public EstadoConservacion EstadoConservacion { get; set; }
        public IEnumerable<Amenaza> Amenazas { get; set; }
        public string Imagen { get; set; }

        public Especie()
        {
           
        }

        /*public Especie(string nombreCientifico, string nombreVulgar, string descripcion, List<Amenaza> amenazas, EstadoConservacion estadoConservacion, List<Ecosistema> ecosistemasHabitados)
		{
			NombreCientifico = nombreCientifico;
			NombreVulgar = nombreVulgar;
			Descripcion = descripcion;
			Amenazas = amenazas;
			EstadoConservacion = estadoConservacion;
			EcosistemasHabitados = ecosistemasHabitados;
			// No necesitas asignar manualmente los valores de Id y UltimoId aquí.
		}*/

        public void Validar()
        {
            if (NombreCientifico.Length > MaxCharNombre || NombreCientifico.Length < MinCharNombre)
            {
                throw new EspecieException("El nombre debe tener entre " + MinCharNombre +
                    " y " + MaxCharNombre + " caracteres");
            }
            if (Descripcion.Length > MaxCharDescripcion || Descripcion.Length < MinCharDescripcion)
            {
                throw new EspecieException("La descripción debe tener entre " + MinCharDescripcion +
                    " y " + MaxCharDescripcion + " caracteres");
            }
            if (string.IsNullOrEmpty(NombreVulgar))
            {
                throw new EspecieException("No se ha proporcionado un nombre vulgar");
            }
            if (string.IsNullOrEmpty(Descripcion))
            {
                throw new EspecieException("No se ha proporcionado una descripción");
            }
            if (RangoTamano == null)
            {
                throw new EspecieException("No se ha proporcionado un rango de tamaño");
            }
            if(RangoTamano.LongitudMinima < 0 || RangoTamano.LongitudMaxima < 0)
            {
                throw new EspecieException("No se ha proporcionado un rango de longitud");
            }
            if (RangoTamano.PesoMinimo < 0 || RangoTamano.PesoMaximo < 0)
            {
                throw new EspecieException("No se ha proporcionado un rango de peso");
            }


        }

   
    }
}
