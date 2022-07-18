using DesafioKinvo.Data;
using DesafioKinvo.WebApi.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace DesafioKinvo.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.ResolveDependencies();
            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(typeof(Startup));
            services.AddCors(options =>
            {
                options.AddPolicy("Development",
                    builder =>
                        builder
                        .WithMethods("GET", "POST", "PUT", "PATCH", "DELETE")
                            .AllowAnyOrigin()
                            .SetIsOriginAllowedToAllowWildcardSubdomains()
                            .AllowAnyHeader());
            });
        }

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
            });
            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }
    }
}
