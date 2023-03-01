using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using ShopBridge.Entities.Entities;
using ShopBridge.Utilities.Repositories;
using ShopBridgeBackEnd.Services;

namespace ShopBridgeBackEnd
{
    public class Startup
    {
        readonly string CorsConfiguration = "_corsConfiguration";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureSevices(IServiceCollection services)
        {
            services.AddDbContext<ShopBridgeContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(c =>
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Shop Bridge API",
                Description = ".NET 6 API",
                Contact = new OpenApiContact
                {
                    Name = "John Batista",
                    Email = "johnk_batista@yahoo.com"
                }

            }));
            services.AddCors(options =>
            {
                options.AddPolicy(name: CorsConfiguration,
                                       builder =>
                                       {
                                           builder.WithOrigins("http://localhost:4200");
                                       });
            });
            services.AddScoped<ProductService>();
            services.AddScoped(typeof(IRepository<>), typeof(ShopBridgeRepository<>));
            services.AddAutoMapper(typeof(Startup));
            services.AddMvc()
               .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(CorsConfiguration);
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
