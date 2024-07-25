using EcosistemasMarinos.LogicaNegocio.Entidades;
using EcosistemasMarinos.LogicaNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.RepositorioEF
{
    public class RepositorioAmenaza : IRepositorioAmenaza
    {
        public EcosistemasMarinosContext Contexto { get; set; }

        public RepositorioAmenaza(EcosistemasMarinosContext ctx)
        {
            Contexto = ctx;
        }

        public void Add(Amenaza obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(Amenaza obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Amenaza> FindAll()
        {
            return Contexto.Amenazas.ToList();
        }

        public Amenaza FindById(int? id)
        {
            throw new NotImplementedException();
        }

        public List<Amenaza> FindObjectsById(IEnumerable<int> ids)
        {
            // Asegúrate de que la lista de IDs no sea nula ni esté vacía
            if (ids == null || !ids.Any())
            {
                throw new ArgumentException("La lista de IDs está vacía o es nula.");
            }

            // Realiza la búsqueda utilizando LINQ en tu contexto
            var amenazas = Contexto.Amenazas
                          .Where(a => ids.Contains(a.Id))
                          .ToList();
            return amenazas;
        }


        public void Update(Amenaza obj)
        {
            throw new NotImplementedException();
        }

      

       
    }
}
