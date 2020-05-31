using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using 依赖注入.Services;

namespace 依赖注入.Extensions
{
    public class DemoServiceBuilder
    {
        public IServiceCollection ServiceCollection { get; set; }
        public DemoServiceBuilder(IServiceCollection services)
        {
            ServiceCollection = services;
        }

        public void SetDemo1()
        {
            ServiceCollection.AddSingleton<IDemoService, Demo1Service>();
        }

        public void SetDemo2()
        {
            ServiceCollection.AddTransient<IDemoService, Demo2Service>();
        }
    }
}
