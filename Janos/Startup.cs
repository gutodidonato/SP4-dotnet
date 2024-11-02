using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Janos.Models;
using Janos.Repositories;
using Janos.Repositories.Interfaces;
using Janos.Data;
using System;
using System.IO;
using System.Reflection;
using Microsoft.OpenApi.Models;
using Janos.Controllers;

namespace Janos
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
            services.AddDbContext<AppDbContext>(options =>
                options.UseOracle(Configuration.GetConnectionString("OracleConnection")));

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ILojaRepository, LojaRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<INotaRepository, NotaRepository>();
            services.AddHttpClient<EnderecoController>();


            services.AddControllers();
            services.AddEndpointsApiExplorer();
            

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Janos API",
                    Version = "v1",
                    Description = "Configuração de endpoints para o app da Go&GetIT ",
                });

                c.EnableAnnotations();

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Janos API v1");
                    c.RoutePrefix = string.Empty; 
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
