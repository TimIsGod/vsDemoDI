using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using 依赖注入.Services;

namespace 依赖注入.Extensions
{
    public static class DemoServiceExtensioncs
    {
        //无配置方式
        public static void AddDemoService(this IServiceCollection services)
        {
            services.AddTransient<IDemoService, Demo1Service>();
        }

        //使用DemoServiceBuilder类实现可以配置服务添加
        public static void AddDemoService(this IServiceCollection services,Action<DemoServiceBuilder> config)
        {
            var builder = new DemoServiceBuilder(services);
            config(builder);
        }
    }
}
