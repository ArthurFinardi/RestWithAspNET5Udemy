using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RestWithAspNET5Udemy.Hypermedia.Enricher;
using RestWithAspNET5Udemy.Hypermedia.Filters;
using RestWithAspNET5Udemy.Model.Context;
using RestWithAspNET5Udemy.Repository.Generic;
using RestWithAspNET5Udemy.Repository.Interfaces;
using RestWithAspNET5Udemy.Services;
using RestWithAspNET5Udemy.Services.Implementation;
using Serilog;
using System.Net.Http.Headers;

namespace RestWithAspNET5Udemy
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Enviroment { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Enviroment = environment;

            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {            
            services.AddControllers();

            var connection = Configuration["SQLServerConnection:SQLServerConnectionString"];
            services.AddDbContext<SQLServerContext>(options => options.UseSqlServer(connection));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Rest API's From 0 to Azure wih ASP .NET Core 5 and Docker",
                        Version = "v1",
                        Description = "API Restful developed in course 'Rest API's From 0 to Azure wih ASP .NET Core 5 and Docker'",
                        Contact = new OpenApiContact
                        {
                            Name = "Árthur Finardi",
                            Url = new System.Uri("https://github.com/ArthurFinardi/ArthurFinardi")
                        }
                    });
            });

            //Configurando consumo de xml e json para envio de req - Content Negociaton
            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;

                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml").ToString());
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json").ToString());
            }).AddXmlSerializerFormatters();


            var filterOptions = new HyperMediaFilterOptions();
            filterOptions.ContentResponseEnricherList.Add(new PersonEnricher());
            filterOptions.ContentResponseEnricherList.Add(new BookEnricher());

            services.AddSingleton(filterOptions);

            //Versioning API
            services.AddApiVersioning();

            //Injeção de dependência
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IBookService, BookService>();
            
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json",
                        "Rest API's From 0 to Azure wih ASP .NET Core 5 and Docker v1"));
            }
            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute("DefaultApi", "{controller=values}/{id?}");
            });
        }
    }
}
