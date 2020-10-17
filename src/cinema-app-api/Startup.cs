using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using cinema_app_api.Data;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using System.Net;

namespace cinema_app_api
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            if(_env.IsEnvironment("docker")) {
                services.AddDbContext<DataContext>(p => p.UseNpgsql(Configuration.GetConnectionString("DockerConnection")));
                Console.WriteLine($"Connection to the dabase: {Configuration.GetConnectionString("DockerConnection")}");
            } else {
                services.AddDbContext<DataContext>(p => p.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
                Console.WriteLine($"Connection to the dabase: {Configuration.GetConnectionString("DefaultConnection")}");
            }
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseForwardedHeaders();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if(env.IsEnvironment("docker")) {
                using(var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope()) {
                    serviceScope.ServiceProvider.GetService<DataContext>().Database.Migrate();
                }
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
