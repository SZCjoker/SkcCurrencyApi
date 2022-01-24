using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SkcCurrencyApi.BLL.Application;
using SkcCurrencyApi.DAL.Interface;
using SkcCurrencyApi.DAL.Repository;

namespace SkcCurrencyApi
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
            services.ConfigureDependencyInjections();
            //services.Configure<IISServerOptions>(options =>
            //{
            //    options.AutomaticAuthentication = true;
            //});
            services.AddCors(config=> {
                config.AddPolicy("CorsPolicy",
                    c => c.WithOrigins("http://localhost:80",
                                       "http://127.0.0.1:80",
                                       "http://192.168.1.105:80"
                                 ).AllowAnyOrigin()
                                 .AllowAnyHeader()
                                 .AllowAnyMethod());
                                // .AllowCredentials());
            });
            services.AddControllers();
            services.AddScoped<ICurrencySevice, CurrencyService>();
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddAuthentication(IISDefaults.AuthenticationScheme);
            services.AddResponseCompression(options =>
            {
                IEnumerable<string> MimeTypes = new[]
                {
                     "text/plain",
                     "application/json"
                 };
                options.EnableForHttps = true;
                options.MimeTypes = MimeTypes;
                options.Providers.Add<BrotliCompressionProvider>();
                options.Providers.Add<GzipCompressionProvider>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
