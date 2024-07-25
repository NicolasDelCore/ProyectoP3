using EcosistemasMarinos.LogicaNegocio.InterfacesRepositorio;
using EcosistemasMarinos.LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using LogicaAccesoDatos.RepositorioEF;
using EcosistemasMarinos.LogicaAplicacion.CasosUso.CUEcosistema;
using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.IEcosistema;
using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.IEspecie;
using EcosistemasMarinos.LogicaAplicacion.CasosUso.CUEspecie;
using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.CUUsuario;
using EcosistemasMarinos.LogicaAplicacion.CasosUso.CUUsuario;
using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.IUsuario;
using EcosistemasMarinos.LogicaAplicacion.CasosUso.CUAmenaza;
using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.IAmenaza;
using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.IPais;
using EcosistemasMarinos.LogicaAplicacion.CasosUso.CUPais;
using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.IEstadoConservacion;
using EcosistemasMarinos.LogicaAplicacion.CasosUso.CUEstadoConservacion;
using EcosistemasMarinos.LogicaAccesoDatos.RepositorioEF;
using EcosistemasMarinos.LogicaAplicacion.CasosUso.CUParametro;
using EcosistemasMarinos.LogicaAplicacion.InterfacesCasosUso.IParametro;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using EcosistemasMarinos.LogicaAplicacion.CasosUso.CULog;

namespace LogicaNegocio
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            //Configuración de autenticación & autorización por cookie según Microsoft: https://learn.microsoft.com/en-us/aspnet/core/security/authentication/cookie?view=aspnetcore-7.0
            //Más info sobre autenticación & autorización por cookies: https://www.c-sharpcorner.com/article/cookie-authentication-in-asp-net-core/
            //Otra guía usada para la autenticación y autorización por cookies: https://dev.to/kazinix/aspnet-core-quick-cookie-authentication-39eb https://referbruv.com/blog/implementing-cookie-authentication-in-aspnet-core-without-identity/

            builder.Services.AddAuthentication("UsuarioLogueado"  //auth config
            ).AddCookie("UsuarioLogueado", options =>
                {
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                    options.SlidingExpiration = true; //por lo que entiendo, renueva la cookie al llegar a la mitad del ExpireTimeSpan
                    options.AccessDeniedPath = "/Session/Forbidden";
                    options.LoginPath = "/Session/Login";
                    options.LogoutPath = "/Session/Logout";
                });
            
            builder.Services.AddHttpContextAccessor(); //auth config


            builder.Services.AddSession();

            //DI Repositorios
            builder.Services.AddScoped<IRepositorioEcosistema, RepositorioEcosistema>();
            builder.Services.AddScoped<IRepositorioEspecie, RepositorioEspecie>();
            builder.Services.AddScoped<IRepositorioEstadoConservacion, RepositorioEstadoConservacion>();
            builder.Services.AddScoped<IRepositorioPais, RepositorioPais>();
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            builder.Services.AddScoped<IRepositorioAmenaza, RepositorioAmenaza>();
            builder.Services.AddScoped<IRepositorioParametro, RepositorioParametro>();
            builder.Services.AddScoped<IRepositorio<Log>, RepositorioLog>();

            //DI Casos de Uso
            builder.Services.AddScoped<IAltaLog, CUAltaLog>();
            builder.Services.AddScoped<IAltaEcosistema, CUAltaEcosistema>();
            builder.Services.AddScoped<IListadoEcosistema, CUListadoEcosistema>();
            builder.Services.AddScoped<IBajaEcosistema, CUBajaEcosistema>();
            builder.Services.AddScoped<IEditarEcosistema, CUEditarEcosistema>();
            builder.Services.AddScoped<IAltaEspecie, CUAltaEspecie>();
            builder.Services.AddScoped<IListadoEspecie, CUListadoEspecie>();
            builder.Services.AddScoped<IAltaUsuario, CUAltaUsuario>();
            builder.Services.AddScoped<ICUBuscarUsuarioPorAlias, CUBuscarUsuarioPorAlias>();
            builder.Services.AddScoped<IListadoAmenaza, CUListadoAmenaza>();
            builder.Services.AddScoped<IListadoPais, CUListadoPais>();
            builder.Services.AddScoped<IBuscarPais, CUBuscarPais>();
            builder.Services.AddScoped<IListadoEstadoConservacion, CUListadoEstadoConservacion>();
            builder.Services.AddScoped<IBuscarEstadoConservacion, CUBuscarEstadoConservacion>();
            builder.Services.AddScoped<IListadoAmenazasPorId, CUListadoAmenazasPorId>();
            builder.Services.AddScoped<IListadoEcosistemasPorId, CUListadoEcosistemasPorId>();
            builder.Services.AddScoped<IFindByNombreEcosistema, CUFindByNombre>();
            builder.Services.AddScoped<IBuscarEcosistemaPorId, CUBuscarEcosistemaPorId>();
            builder.Services.AddScoped<IModificarMinCharNombre, CUModificarMinCharNombre>();
            builder.Services.AddScoped<IModificarMaxCharNombre, CUModificarMaxCharNombre>();
            builder.Services.AddScoped<IModificarMinCharDescripcion, CUModificarMinCharDescripcion>();
            builder.Services.AddScoped<IModificarMaxCharDescripcion, CUModificarMaxCharDescripcion>();
            builder.Services.AddScoped<IListadoParametro, CUListadoParametro>();
            builder.Services.AddScoped<IBuscarParametroPorId, CUBuscarParametroPorId>();
            builder.Services.AddScoped<IBuscarEspeciePorId, CUBuscarEspeciePorId>();
            builder.Services.AddScoped<IVerificarEcosistema, CUVerificarEcosistema>();
            builder.Services.AddScoped<IVerificarUnicidadEspecie, CUVerificarUnicidadEspecie>();
            builder.Services.AddScoped<IVerificarAmenaza, CUVerificarAmenaza>();
            builder.Services.AddScoped<IEditarEspecie, CUEditarEspecie>();
            builder.Services.AddScoped<IEditarEcosistema, CUEditarEcosistema>();
        

            /*CONEXIÓN A LA BD*/
            ConfigurationBuilder confBuilder = new ConfigurationBuilder();
            confBuilder.AddJsonFile("appsettings.json", false, true);
            var config = confBuilder.Build();

            string? strCon = config.GetConnectionString("MiConexion");

            if (strCon != null) {
                builder.Services.AddDbContextPool<EcosistemasMarinosContext>(options => options.UseSqlServer(strCon));
            } else {
                throw new Exception("String de conexión nulo o incorrecto.");
            }


            /*ESTO SOLO SE EJECUTA UNA VEZ CUANDO CARGA LA APLICACIÓN */
            /*DbContextOptionsBuilder<EcosistemasMarinosContext> b = new DbContextOptionsBuilder<EcosistemasMarinosContext>();
            b.UseSqlServer(strCon);
            var opciones = b.Options;
            EcosistemasMarinosContext ctx = new EcosistemasMarinosContext(opciones);
            RepositorioParametro repo = new RepositorioParametro(ctx);
            Especie.MinCharNombre = int.Parse(repo.BuscarValorPorNombre("MinCharNom"));
            Especie.MaxCharNombre = int.Parse(repo.BuscarValorPorNombre("MaxCharNombre"));
            Especie.MinCharDescripcion = int.Parse(repo.BuscarValorPorNombre("MinCharDescripcion"));
            Especie.MinCharDescripcion = int.Parse(repo.BuscarValorPorNombre("MinCharDescripcion"));*/


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();


            app.UseAuthentication(); //auth config

            app.UseRouting();

            app.UseAuthorization();
            
            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}