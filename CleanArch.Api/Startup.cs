using Application.Cqrs.OvertimePeriodDetail.Commands;
using Application.Cqrs.OvertimePeriods.Commands;
using ClaroFidelizacion.Api.Configurations;
using CleanArch.Infra.Data.Context;
using CleanArch.Infra.Ioc;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.WebUI.Filters;
using CleanArchitecture.WebUI.Services;
using Core.Filter;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using WebApi.Middleware;

namespace Humans.Payroll.Api
{
    public class Startup
    {

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            // Código para evitar referencia circular en los controladores.
            services.AddControllers(options => { 
            
            }
             // handle exceptions thrown by an action
           );

            services.AddDbContext<U27ApplicationDBContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("U27AplicationDBContext"));
            });


            services.AddSingleton<ICurrentUserService, CurrentUserService>();
            services.AddHttpContextAccessor();

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            //add before the MVC
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Authentication:SecretKey"]))
                    
                };
            });
            services.AddMediatR(typeof(Startup));
            services.AddMediatR(typeof(UploadOvertimesPeriodCommand).GetTypeInfo().Assembly);

            services.AddCors();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HUMANS.GTH", Version = "v1" });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.TagActionsBy(api => api.GroupName);
                c.DocInclusionPredicate((name, api) => true);
            });
            services.RegisterAutoMapper();

            RegisterServices(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseFileServer(new FileServerOptions
            {
                FileProvider = new PhysicalFileProvider(
                        Path.Combine(Directory.GetCurrentDirectory(), "Resources")),
                        RequestPath = "/Resources",
                        EnableDefaultFiles = true
            });
            app.UseMiddleware<ErrorHandlerMiddleware>();

         

            // global cors policy
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                //
                // string swaggerJsonBasePath = string.IsNullOrEmpty(c.RoutePrefix) ? "." : "..";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HUMANS.GTH");
                c.RoutePrefix = string.Empty;
            });
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void RegisterServices(IServiceCollection services)
        {
            DependencyContainer.RegisterServices(services);

            services.AddMvc(options =>
            {
                options.Filters.Add<ValidationFilter>();
                options.Filters.Add<ApiExceptionFilterAttribute>();

            }).AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblyContaining<PostOvertimeCommandValidator>();
            });



        }
    }

}
