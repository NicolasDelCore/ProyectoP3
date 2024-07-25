using EcosistemasMarinos.LogicaNegocio.Entidades;
using EcosistemasMarinos.LogicaNegocio.Parametros;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.RepositorioEF
{
    public class EcosistemasMarinosContext : DbContext
    {
        public DbSet<Ecosistema> Ecosistemas { get; set; }
        public DbSet<Amenaza> Amenazas { get; set; }
        public DbSet<Especie> Especies { get; set; }
        public DbSet<EstadoConservacion> EstadosConservacion { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Parametro> Parametros { get; set; }
        public DbSet<Log> Logs { get; set; }

        public EcosistemasMarinosContext(DbContextOptions<EcosistemasMarinosContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ecosistema>().OwnsOne(eco => eco.Ubicacion);
            modelBuilder.Entity<Especie>().OwnsOne(esp => esp.RangoTamano);

            modelBuilder.Entity<Ecosistema>()
                        .HasMany(eco => eco.EspeciesQueHabitan)
                        .WithMany(esp => esp.EcosistemasQueHabitan)
                        .UsingEntity<Dictionary<string, object>>(
                          "EspeciesQueHabitan",
                          x => x.HasOne<Especie>().WithMany()
                          .OnDelete(DeleteBehavior.NoAction).IsRequired(false),
                          x => x.HasOne<Ecosistema>()
                          .WithMany().OnDelete(DeleteBehavior.NoAction).IsRequired(false));

            modelBuilder.Entity<Ecosistema>()
                        .HasMany(eco => eco.EspeciesQuePuedenHabitar)
                        .WithMany(esp => esp.EcosistemasQuePuedenHabitar)
                        .UsingEntity<Dictionary<string, object>>(
                          "EspeciesQuePuedenHabitar",
                          y => y.HasOne<Especie>().WithMany()
                          .OnDelete(DeleteBehavior.NoAction).IsRequired(false),
                          y => y.HasOne<Ecosistema>()
                          .WithMany().OnDelete(DeleteBehavior.NoAction).IsRequired(false));


            
            //modelBuilder.Entity<Ecosistema>().HasOne(e => e.Especies).WithMany(es => es.Ecosistemas).OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);
        }


    }



}
