using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NJsonSchema;
using NSwag.AspNetCore;
using System.Reflection;
using NSwag;
using NSwag.SwaggerGeneration.Processors.Security;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;

namespace camunda.nlx.service
{
    public class YamlOutputFormatter : OutputFormatter
    {
        public YamlOutputFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/yaml"));
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context) => Task.CompletedTask;
    }

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
            services.AddNodeServices();
            services.AddMvc(options =>
            {
                options.OutputFormatters.Add(new YamlOutputFormatter());
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwagger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseStaticFiles();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwaggerUi3(typeof(Startup).GetTypeInfo().Assembly, settings =>
            {
                settings.SwaggerUiRoute = "/swagger";
                // settings.GeneratorSettings.DocumentProcessors.Add(new SecurityDefinitionAppender("X-NLX-Request-User-Id", new SwaggerSecurityScheme
                // {
                //     Type = SwaggerSecuritySchemeType.ApiKey,
                //     Name = "X-NLX-Request-User-Id",
                //     In = SwaggerSecurityApiKeyLocation.Header,
                //     Description = "X-NLX-Request-User-Id"
                // }));

                settings.GeneratorSettings.DefaultPropertyNameHandling = 
                    PropertyNameHandling.CamelCase;
                settings.PostProcess = document =>
                {

                    document.Info.Version = "1.0.0";
                    document.Info.Title = "Camunda NLX Service";
                    document.Info.Description = "NLX Compliant API for using the Camunda Business Process Engine on the inter organizational transport ring";
                    // document.Info.TermsOfService = "This is for demo purposes only, do NOT use in production";
                    document.Info.Contact = new NSwag.SwaggerContact
                    {
                        Name = "Sjef van Leeuwen",
                        Email = "sjef.van.leeuwen@wigo4it.nl",
                        Url = "https://github.com/sjefvanleeuwen/"
                    };
                    document.Info.License = new NSwag.SwaggerLicense
                    {
                        Name = "Use under European Union Public License, version 1.2 (EUPL-1.2)",
                        Url = "https://opensource.org/licenses/EUPL-1.1"
                    };
                };
            });

            // Enable the Swagger UI middleware and the Swagger generator

            app.UseHttpsRedirection();
            app.UseMvc(routes =>
   {
       routes.MapRoute(
           name: "default",
           template: "/swagger");
   });
            app.UseSwaggerReDocWithApiExplorer(s =>
            {
                s.SwaggerRoute = "/redoc/v1/swagger.json";
                s.SwaggerUiRoute = "/redoc";
            });
        }
    }
}
