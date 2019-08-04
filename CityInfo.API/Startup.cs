﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using Newtonsoft.Json.Serialization;//***
using Microsoft.AspNetCore.Mvc.Formatters;
using CityInfo.API.Services;
using Microsoft.Extensions.Configuration;

namespace CityInfo.API
{
    public class Startup
    {
        public static IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddMvcOptions(x => x.OutputFormatters.Add(
                    new XmlDataContractSerializerOutputFormatter()));


            //***By default, Json.NET automatically returns objects with properties names using camelCase. To override this see the code below.
            //services.AddMvc()
            //    .AddJsonOptions(o =>
            //    {
            //        if (o.SerializerSettings.ContractResolver != null)
            //        {
            //            var castedResolver = o.SerializerSettings.ContractResolver as DefaultContractResolver;

            //            castedResolver.NamingStrategy = null;
            //        }
            //    });

#if DEBUG
            services.AddTransient<IMailService, LocalMailService>();
#else
            services.AddTransient<IMailService, CloudMailService>();
#endif

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStatusCodePages();
            app.UseMvc();

            //app.Run((context) =>
            //{
            //    throw new Exception("Example");
            //});
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
