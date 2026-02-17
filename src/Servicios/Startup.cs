using System;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Negocio;
using AccesoDatos;

namespace Servicios
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();

            var connectionString = _configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("DefaultConnection is missing.");
            services.AddDbContext<AccesoDatos.PruebaSDContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IObtenerUsuariosCasoUso, ObtenerUsuariosCasoUso>();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use(next => async (context) =>
            {
                try
                {
                    await next(context);
                }
                catch (Exception)
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";
                    var json = System.Text.Json.JsonSerializer.Serialize(new { error = "Ha ocurrido un error. Por favor, intente de nuevo." });
                    var bytes = Encoding.UTF8.GetBytes(json);
                    await context.Response.Body.WriteAsync(bytes);
                }
            });

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors();
            app.UseRouting();
            if (!env.IsDevelopment())
                app.UseHttpsRedirection();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
