using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using POC.Adapters.MySqlDataAccess.Context;
using POC.Modules.Infrastructure.IoC;
using POC.Adapters.MySqlDataAccess.Model;
using System.Text.Encodings.Web;

namespace POC.Ports.OrderAPI
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

            var connection = Configuration.GetConnectionString("MySqlConnectionString");
            services.AddDbContext<MySqlContext>(options =>
                options.UseMySQL(connection)
            );


            services.AddControllers(options =>{
            }).AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                options.JsonSerializerOptions.Encoder = JavaScriptEncoder.Default;
            });

            #region Cors
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
            #endregion

            #region Swagger
            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "POC",
                        Version = "v1",
                        Description = "POC APIs",
                        Contact = new OpenApiContact
                        {
                            Name = "POC APIs"
                        }
                    });
            });
            #endregion

            //Services
            RegisterServices(services);
        }

        private void RegisterServices(IServiceCollection services)
        {
            new RootBootstrapper().BootstrapperRegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MySqlContext mySqlContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            #region Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "POC");
            });
            #endregion

            InitializeDB.Initialize(mySqlContext);
        }
    }
}
