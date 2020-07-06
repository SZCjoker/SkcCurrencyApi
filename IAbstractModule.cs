using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkcCurrencyApi.Utility
{
 public interface IAbstractModule
    {
         /// <summary>
        /// 自定義模組容器標記
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        void Load(IServiceCollection services, IConfiguration configuration);
    }
}
