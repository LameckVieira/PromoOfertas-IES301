using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Microsoft.OpenApi.Models;
using System.IO;
using System.Reflection;

namespace ies_301_WebApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()

            .AddNewtonsoftJson(options =>
            {
                // Ignora os loopings nas consultas

                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

                // Ignora valores nulos ao fazer junções nas consultas

                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });

            services.AddCors(options => {
                options.AddPolicy("CorsPolicy",
                    builder => {
                        builder.WithOrigins("http://localhost:3000", "http://localhost:19006", "http://localhost:19002")
                                                                    .AllowAnyHeader()
                                                                    .AllowAnyMethod();
                    }
                );
            });


            // Register the Swagger generator, defining 1 or more Swagger documents

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ies_301_WebApi", Version = "v1" });

                //// Set the comments path for the Swagger JSON and UI.
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);
            });


            //define a forma de autenticação : no caso usaremos o (JwtBearer)
            services
                    .AddAuthentication(options =>
                    {
                        options.DefaultAuthenticateScheme = "JwtBearer";
                        options.DefaultChallengeScheme = "JwtBearer";
                    })


                //define os parametros de validação do token
                .AddJwtBearer("JwtBearer", options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        //quem está emitindo
                        ValidateIssuer = true,

                        //quem está validando
                        ValidateAudience = true,

                        //define que o tempo de expiração será validado
                        ValidateLifetime = true,

                        //forma de criptografia
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Kelm-chave-autenticacao")),

                        //tempo de expiração do token
                        ClockSkew = TimeSpan.FromMinutes(30),

                        //nome do issuer, de onde está vindo
                        ValidIssuer = "ies_301_WebApi",

                        //nome do audience, de onde está indo
                        ValidAudience = "ies_301_WebApi"
                    };
                });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ies_301_WebApi");
                c.RoutePrefix = string.Empty;
            });


            app.UseAuthentication();


            app.UseAuthorization();

            app.UseCors("CorsPolicy");


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
