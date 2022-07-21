using ControleInvestimentos.Aplication;
using ControleInvestimentos.Aplication.Interfaces;
using ControleInvestimentos.Domain.Core.Interfaces.Repositorys;
using ControleInvestimentos.Domain.Core.Interfaces.Services;
using ControleInvestimentos.Domain.Services;
using ControleInvestimentos.Infrastructure.Data;
using ControleInvestimentos.Infrastructure.Data.Repositotrys;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleInvestimentos.API
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
            #region [Context]
            services.AddDbContext<PgSqlContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("Default"),
                assembly => assembly.MigrationsAssembly(typeof(PgSqlContext).Assembly.FullName));
            });
            #endregion

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Constrole Investimentos", Version = "v1", });
            });
            services.AddControllers();

            services.AddScoped<IApplicationServiceCliente, ApplicationServiceCliente>();
            services.AddScoped<IApplicationServiceTransacao, ApplicationServiceTransacao>();
            services.AddScoped<IRepositoryCliente, RepositoryCliente>();
            services.AddScoped<IRepositoryTransacao, RepositoryTransacao>();
            services.AddScoped<IServiceCliente, ServiceCliente>();
            services.AddScoped<IServiceTransacao, ServiceTransacao>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }
    }
}
