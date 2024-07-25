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
    public class RepositorioEcosistema : IRepositorioEcosistema
    {

        public EcosistemasMarinosContext Contexto { get; set; }
        public RepositorioEcosistema(EcosistemasMarinosContext ctx)
        {
            Contexto = ctx;
        }
        public void Add(Ecosistema ecosistema)
        {
            // Verificar si el correo electrónico ya existe en la base de datos
            bool ecosistemaExists = Contexto.Ecosistemas.Any(e => e.Id == ecosistema.Id);

            if (!ecosistemaExists)
            {
                try
                {
                    ecosistema.Validar();
                    Contexto.Ecosistemas.Add(ecosistema);
                    Contexto.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }    
            }
            else
            {
                // El id ya existe en la base de datos, puedes manejar el error aquí
                throw new InvalidOperationException("El ecosistema ya existe.");
            }
        }

        public void Delete(Ecosistema ecosistema) {
            try {
                if (ecosistema != null) {
                    // Verificar si hay alguna especie asociada.
                    var ok = Contexto.Ecosistemas.Include(eco => eco.EspeciesQueHabitan)
                                                 .Where(eco => eco.Id == ecosistema.Id).FirstOrDefault().EspeciesQueHabitan.Count == 0;
                    // No hay especies asociadas, se puede eliminar.
                    if (ok) {
                        //Elimino las amenazas asociadas a ese ecosistema.
                        var eco = Contexto.Ecosistemas.Include(e => e.Amenazas)
                                 .SingleOrDefault(e => e.Id == ecosistema.Id);
                        eco.Amenazas.Clear();

                        //Elimino las especies que pueden habitar.
                        var ecos = Contexto.Ecosistemas.Include(e => e.EspeciesQuePuedenHabitar)
                                 .SingleOrDefault(e => e.Id == ecosistema.Id);
                        ecos.EspeciesQuePuedenHabitar.Clear();

                        Contexto.Ecosistemas.Remove(eco);
                        Contexto.SaveChanges();

                    } else {
                        // Hay especies asociadas, no se puede eliminar
                        throw new InvalidOperationException("No se puede eliminar el ecosistema debido a que hay especies asociadas.");
                    }
                } else {
                    throw new InvalidOperationException("No se proporcionó un ecosistema");
                }
            } catch (Exception) {
                throw;
            }
        }

        public IEnumerable<Ecosistema> FindAll()
        {
            return Contexto.Ecosistemas.ToList();
        }

        public List<Ecosistema> FindObjectsById(IEnumerable<int> ids)
        {
            // Asegúrate de que la lista de IDs no sea nula ni esté vacía
            if (ids == null || !ids.Any())
            {
                throw new ArgumentException("La lista de IDs está vacía o es nula.");
            }

            // Realiza la búsqueda utilizando LINQ en tu contexto (reemplaza "Contexto" con el nombre real de tu contexto)
            var ecosistemas = Contexto.Ecosistemas
                          .Where(a => ids.Contains(a.Id))
                          .ToList();

            return ecosistemas;
        }

        public void Update(Ecosistema ecosistema)
        {
            Contexto.Ecosistemas.Update(ecosistema);
            Contexto.SaveChanges();
        }

        public Ecosistema FindById(int? id)
        {
            var ecosistema = Contexto.Ecosistemas
                            .Include(Eco => Eco.EstadoConservacion)
                            .Include(Eco => Eco.EspeciesQueHabitan)
                            .Where(eco => eco.Id == id)
                            .FirstOrDefault();
            return ecosistema;
        }

        public Ecosistema? FindByNombre(string nombre)
        {
            return Contexto.Ecosistemas
                .Where(e => e.Nombre == nombre)
                .FirstOrDefault();
        }

        public bool VerificarUnicidadEspecie(Especie especie, Ecosistema ecosistema)
        {
            var chk = Contexto.Especies
            .Include(esp => esp.EcosistemasQueHabitan)
            .SelectMany(esp => esp.EcosistemasQueHabitan)
            .Where(eco => eco.Id == ecosistema.Id)
            .ToList()
            .Any(e => e.EspeciesQueHabitan.Contains(especie));

            return chk;
        }
    }
}