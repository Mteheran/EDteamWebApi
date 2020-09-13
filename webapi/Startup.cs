using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebApiRoutesResponses.Services;
using WebApiRoutesResponses.MiddleWares;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using WebApiRoutesResponses.Context;
using Microsoft.OpenApi.Models;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.OData.Edm;
using Microsoft.AspNet.OData.Builder;
using WebApiRoutesResponses.Models;

namespace WebApiRoutesResponses
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
            services.AddControllers(config =>
            {
                config.EnableEndpointRouting = false;
                //var policy = new AuthorizationPolicyBuilder()
                //                .RequireAuthenticatedUser()
                //                .Build();
                //config.Filters.Add(new AuthorizeFilter(policy));
            }).AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddScoped<IUserDataService,UserDataService>();
            services.AddCors(p=>
            {
                p.AddPolicy("MyPolicy",
                builder=> {
                     builder.AllowAnyHeader()
                        .WithOrigins("http://127.0.0.1:5500")
                        .WithMethods("GET", "POST", "PUT", "DELETE").
                        Build();
                });

            });  

            var key = Encoding.ASCII.GetBytes(Configuration.GetValue<string>("SecretKey"));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => {

                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateLifetime =  true,
                        ValidIssuer = "",
                        ValidAudience = "",
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        ValidateIssuerSigningKey= true
                    };
            });  

            //services.AddDbContext<ApiAppContext>(options =>
            // options.UseInMemoryDatabase("AppDB"));
            
            // using Microsoft.EntityFrameworkCore;
            services.AddDbContext<ApiAppContext>(options =>
                options.UseSqlServer(@"Data Source=MTEHERAN\LOCALDB;Initial Catalog=EDteamApi;Integrated Security=SSPI;"));

            services.AddResponseCaching();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ToDo API",
                    Description = "A simple example ASP.NET Core Web API",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Shayne Boyer",
                        Email = string.Empty,
                        Url = new Uri("https://twitter.com/spboyer"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                });
            });

            services.AddOData();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                app.UseExceptionHandler("/error");
            }
            else
            {
              
            }

            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });


            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            //app.UseHttpsRedirection();
            app.UseRouting();

            app.UseResponseCaching();

            app.UseCors();

            //app.UseAuthentication();

            //app.UseAuthorization();

            app.UseMvc(routeBuilder =>
            {
                routeBuilder.Expand().Select().OrderBy().Filter();
                routeBuilder.EnableDependencyInjection();
                routeBuilder.MapODataServiceRoute("odata", "odata", GetEdmModel());
            });


            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();

            //    endpoints.MapGet("/MyRoot", async context => 
            //    {   
            //       await context.Response.WriteAsync("Hola desde myroot");

            //    });
            //});

            app.UseWelcomePage();
            
            app.UseStatusMiddleWare();


            //app.Run(async context=>
            //{
            //    await context.Response.WriteAsync("URL no encontrada");
            //});
        }

         IEdmModel GetEdmModel()
        {
            var odataBuilder = new ODataConventionModelBuilder();
            odataBuilder.EntitySet<User>("Users");

            return odataBuilder.GetEdmModel();
        }
    }
}
