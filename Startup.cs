using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;

using APIRestBanco.Data;
using APIRestBanco.Models;

namespace APIRestBanco
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            //Service Entity Framework Postgresql
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<BancoContext>(
                    options => options.UseNpgsql(
                        Configuration.GetConnectionString("BancoDB")));

            //Service Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { 
                    Title = "Banco APIRest",
                    Version = "v1",
                    Description = "A simple example ASP.NET Core Web API",
                    Contact = new Contact { Name = "Bruno Medeiros", Email = "bruno.medeirs@gmail.com" },
                    License = new License { Name = "MIT License", Url = "https://example.com/license" }
                });
            });

            //Services escopo
            services.AddScoped<IContaRepositorio, ContaRepositorio>();
            services.AddScoped<ITransacaoRepositorio, TransacaoRepositorio>();

            //Services MVC
            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Ativa Swagger para gerar JSON
            app.UseSwagger();

            // Swagger-ui (HTML, JS, CSS, etc.), a partir do JSON.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Banco APIRest");
            });

            app.UseMvc();
        }
    }
}
