using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebSockets;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using 依赖注入.Extensions;
using 依赖注入.Services;

namespace 依赖注入
{
    //配置web应用所需的服务和中间件
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        //注册服务
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //services.AddTransient<服务接口，服务实现> (); 瞬时，每次请求都建立一个
            //services.AddSingleton<服务接口，服务实现> (); 每一次都使用相同的实例
            //services.AddScoped < 服务接口，服务实现 > (); 作用域，同一个线程里只实例化一次

            //第一种注册方式,同一个service注册只有最后注册的实现类有效
            services.AddTransient<IDemoService, Demo1Service>();
            services.AddTransient<IDemoService, Demo2Service>();

            //第二种注册方式，使用扩展方法.参考DemoServiceExtensions.cs
            services.AddDemoService();

            //第二种注册方式，可配置.参考DemoServiceExtensions.cs
            services.AddDemoService(builder => builder.SetDemo1());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //主机的web应用启动类
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute()
            //{
            //    endpoints.MapControllerRoute("Default", "{controller=Home}/{action=Index}/{id?}");
            //    //endpoints.MapGet("/", async context =>
            //    //{
            //    //    await context.Response.WriteAsync("Hello World!");
            //    //});

               
            //}
            );
        }
    }
}
