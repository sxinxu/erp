using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using erpcore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using GraphiQl;
using erpWebAPI.Models;
using GraphQL.Types;
using GraphQL;
using erpWebAPI.Types;

namespace erpWebAPI
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
            services.Configure<ConnectionStringSettings>(Configuration.GetSection("ConnectionStringSettings"));
            services.AddSingleton<IPlatformServiceFactory, PlatformServiceFactory>();
            //services.AddSingleton<IHostedService, AmazonSyncHostService>();
            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                                                              .AllowAnyMethod()
                                                               .AllowAnyHeader().AllowCredentials()));
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(JsonExceptionFilter));
            });

            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<ERPQuery>();
            services.AddSingleton<OrderType>();
            services.AddSingleton<SearchOrderInputType>();
            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new ERPSchema(new FuncDependencyResolver(type => sp.GetService(type))));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(b => b.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());
            app.UseGraphiQl();
            app.UseMvc();
            app.UseStaticFiles();
        }

        public class JsonExceptionFilter : IExceptionFilter
        {
            public void OnException(ExceptionContext context)
            {
                var result = new ObjectResult(new
                {
                    code = 500,
                    message = "A server error occurred.",
                    detailedMessage = context.Exception.Message,
                    stackTrace = context.Exception.StackTrace
                });

                result.StatusCode = 500;
                context.Result = result;
            }
        }
    }
}
