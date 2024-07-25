using EcosistemasMarinos.LogicaNegocio.Entidades;
using EcosistemasMarinos.LogicaNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.RepositorioEF
{
    public class RepositorioEspecie : IRepositorioEspecie
    {
        public EcosistemasMarinosContext Contexto { get; set; }

        public RepositorioEspecie(EcosistemasMarinosContext ctx)
        {
            Contexto = ctx;
        }
        public void Add(Especie especie)
        {
            // Verificar si el correo electrónico ya existe en la base de datos
            bool especieExists = Contexto.Especies.Any(e => e.Id == especie.Id);

            if (!especieExists)
            {
                try
                {
                    especie.Validar();
                    Contexto.Especies.Add(especie);
                    Contexto.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            else
            {
                // El id ya existe en la base de datos, puedes manejar el error aquí
                throw new InvalidOperationException("La especie ya existe");
            }
        }

        public void Delete(Especie obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Especie> FindAll()
        {
            return Contexto.Especies.ToList();
        }

        public Especie FindById(int? id)
        {
            var especie = Contexto.Especies
                            .Include(Es => Es.EstadoConservacion)
                            .Include(Es => Es.EcosistemasQueHabitan)
                            .Include(Es => Es.EcosistemasQuePuedenHabitar)
                            .Where(es => es.Id == id)
                            .FirstOrDefault();
            return especie;
        }


        //----------------------------------------------- CONSULTA POR NOMBRE CIENTÍFICO -----------------------------------------------
        public IEnumerable<Especie> FindByNombre(string nombreCientifico)
        {
            return Contexto.Especies
                    .Where(e => e.NombreCientifico.Contains(nombreCientifico))
                    .ToList();
        }

        //---------------------------------------------- CONSULTA POR ESPECIE EN PELIGRO ------------------------------------------------
        public IEnumerable<Especie> filtrarEspeciesenPeligro()
        {
            var especiesenpeligro = Contexto.Especies
                .Include(Es => Es.EcosistemasQueHabitan)
                .ThenInclude(Eco => Eco.EstadoConservacion)
                .Include(Es => Es.EcosistemasQueHabitan)
                .ThenInclude(Eco => Eco.Amenazas)
                .Where(e =>
                    e.EstadoConservacion.EstadoPorcentual < 60 ||
                    e.Amenazas.Count() > 3 ||
                    (e.EcosistemasQueHabitan.Any(ecosistema =>
                        ecosistema.Amenazas.Count() > 3 &&
                        ecosistema.EstadoConservacion.EstadoPorcentual < 60)))
                .ToList();

            return especiesenpeligro;
        }

        //---------------------------------------------- CONSULTA POR RANGO DE PESO ------------------------------------------------
        public IEnumerable<Especie> FiltrarEspeciesPorRangoDePeso(decimal? pesoMinimo, decimal? pesoMaximo)
		{
            if (pesoMinimo > pesoMaximo || pesoMinimo == null || pesoMaximo == null || pesoMaximo < 0.01M || pesoMinimo < 0.01M) { throw new InvalidOperationException("Error filtrando Especies por Peso: Peso Mínimo no puede ser menor a Peso Máximo y ambos deben ser mayores a 0.01"); }
			var especiesEnRangoDePeso = Contexto.Especies
                .Where(e => e.RangoTamano.PesoMinimo >= pesoMinimo && e.RangoTamano.PesoMaximo <= pesoMaximo)
				.ToList();
			return especiesEnRangoDePeso;
		}

        //-------------------------------------------- CONSULTA POR ECOSISTEMA HABITADO ------------------------------------------------
        public IEnumerable<Especie> FiltrarEspeciesPorEcosistema(string nombreEcosistema)
        {
            var especiesPorEcosistema = Contexto.Especies
                //.Include(Es => Es.EcosistemasQueHabitan)
                .Where(e => e.EcosistemasQueHabitan.Any(ecosistema => ecosistema.Nombre == nombreEcosistema))
                .ToList();

            return especiesPorEcosistema;
        }

        //-------------------------------------------- CONSULTA POR ECOSISTEMAS NO HABITABLES POR ESPECIE ------------------------------------------------
        public IEnumerable<Ecosistema> ObtenerEcosistemasNoHabitablesPorEspecie(int? especieId)
        {

            if (especieId == null || especieId < 0)
            {
                throw new InvalidOperationException("Error: ID de especie inválido.");
            }

            var especie = FindById(especieId);

            var ecosistemasNoHabitables = Contexto.Ecosistemas
                .Where(ecosistema => !especie.EcosistemasQuePuedenHabitar.Contains(ecosistema));

            return ecosistemasNoHabitables;
        }

        //-------------------------------------------- CONSULTA POR ECOSISTEMAS HABITADOS POR ESPECIE ------------------------------------------------

        public IEnumerable<Ecosistema> ObtenerEcosistemasHabitadosPorEspecie(int? especieId)
        {

            if (especieId == null || especieId <= 0)
            {
                throw new InvalidOperationException("No existe una especie con ese ID.");
            }

            var especie = FindById(especieId);

            var ecosistemasHabitadosPor = Contexto.Especies
                .SelectMany(especie => especie.EcosistemasQueHabitan).Distinct()
                .ToList();

            return ecosistemasHabitadosPor;
        }

        public void Update(Especie especie)
        {
            Contexto.Especies.Update(especie);
            Contexto.SaveChanges();
        }

        public bool Verificar(Especie especie, Ecosistema ecosistema)
        {
            // Comprueba si el ecosistema está en la lista EcosistemasQuePuedenHabitar de la especie            
            return Contexto.Especies
            .Select(especie => especie.EcosistemasQuePuedenHabitar)
            .SelectMany(ecos => ecos)
            .Any(eco => eco.Id == ecosistema.Id);
        }

        public bool VerificarAmenaza(Especie especie, Ecosistema ecosistema)
        {// Obtiene las listas de amenazas de la especie y el ecosistema
            var amenazasDeEspecie = Contexto.Especies
                .Select(especie => especie.Amenazas)
                .SelectMany(amenaza => amenaza)
                .ToList();

            var amenazasDeEcosistema = Contexto.Ecosistemas
                .Select(ecosistema => ecosistema.Amenazas)
                .SelectMany(amenaza => amenaza)
                .ToList();

            // Comprueba si las listas de amenazas son idénticas (tienen los mismos elementos)
            return amenazasDeEspecie.All(a => amenazasDeEcosistema.Contains(a));
        }
    }
}
