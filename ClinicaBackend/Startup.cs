using ClinicaBackend.Contexts;
using ClinicaBackend.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaBackend
{
    public class Startup
    {
        //private readonly string _MyCors= "MyCors";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnectionStrings")));

            /* services.AddCors(options =>
             {
                 options.AddPolicy(name: _MyCors, builder =>
                 {
                     //builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "https://localhost:44357").AllowAnyHeader().AllowAnyMethod();
                     builder.WithOrigins("http://localhost");
                 });
             });*/

            services.AddCors();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

           
            
            /*app.UseCors(_MyCors);*/

           //app.UseMiddleware<BasicAuthenticationMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            //app.UseAuthentication();

            app.UseCors(x => x.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
