using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkcCurrencyApi.BLL.Application;
using SkcCurrencyApi.DAL.Interface;
using SkcCurrencyApi.DAL.Repository;
using SkcCurrencyApi.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;

namespace SkcCurrencyApi.ModelConfig
{
    [Injection]
    public class ServicesConfig 
    {
        public void Load(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICurrencySevice, CurrencyService>();
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

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
    }
}
