using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FichaAcademia.AcessoDados;
using FichaAcademia.AcessoDados.Interfaces;
using FichaAcademia.AcessoDados.Repositorios;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rotativa.AspNetCore;

namespace FichaAcademia
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        

        public void ConfigureServices(IServiceCollection services)
        {
            // Configuração de acesso ao Banco de Dados
            services.AddDbContext<Contexto>(opcoes => opcoes.UseSqlServer(Configuration.GetConnectionString("Conexao")));

            // Registrando repositorio

            services.AddTransient<ICategoriaExercicioRepositorio, CategoriaExercicioRepositorio>();
            services.AddTransient<IAdministradorRepositorio, AdministradorRepositorio>();
            services.AddTransient<IExercicioRepositorio, ExercicioRepositorio>();
            services.AddTransient<IProfessorRepositorio, ProfessorRepositorio>();



            // Configuração de Autenticação
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(opcoes =>
                {
                    opcoes.LoginPath = "/Administradores/Login";
                });

            // Configuração de Sessões
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSession(opcoes =>
            {
                opcoes.IdleTimeout = TimeSpan.FromHours(1); // Cada sessão vai durar 1 hora
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }
        

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseSession(); // Deixando claro ao app que estamos utilizando Sessão
            app.UseAuthentication(); // Deixando claro ao app que estamos utilizando Autenticação
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            RotativaConfiguration.Setup(env); // Configurando o Rotativa no app

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Administradores}/{action=Login}/{id?}");
            });
        }
    }
}
