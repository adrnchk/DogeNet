// <copyright file="Startup.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.IdentityServer
{
    using System.IO;
    using DogeNet.BLL.Extentions;
    using DogeNet.BLL.Features.Messages.SendMessage;
    using DogeNet.DAL;
    using DogeNet.DAL.Models;
    using DogeNet.IdentityServer.ViewModels;
    using MediatR;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.FileProviders;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.AppConfiguration = configuration;
            StaticConfig = configuration;
        }

        public static IConfiguration StaticConfig { get; private set; }

        public IConfiguration AppConfiguration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DBContext>(config =>
            {
                config.UseSqlServer(this.AppConfiguration.GetConnectionString(nameof(DBContext)));
            })
                .AddIdentity<IdentityUser, IdentityRole>(config =>
                {
                    config.Password.RequireDigit = false;
                    config.Password.RequireLowercase = false;
                    config.Password.RequireNonAlphanumeric = false;
                    config.Password.RequireUppercase = false;
                    config.Password.RequiredLength = 6;
                })
                .AddEntityFrameworkStores<DBContext>();

            services.AddIdentityServer()
              .AddAspNetIdentity<IdentityUser>()
              .AddInMemoryIdentityResources(Configuration.IdentityResources)
              .AddInMemoryClients(Configuration.Clients)
              .AddInMemoryApiResources(Configuration.ApiResources)
              .AddInMemoryApiScopes(Configuration.ApiScopes)
              .AddDeveloperSigningCredential();

            services.ConfigureApplicationCookie(config =>
            {
                config.Cookie.Name = "IdentityServer.Cookie";
                config.LoginPath = "/Account/Login";
                config.LogoutPath = "/Account/Logout";
            });

            services.AddCors(options =>
            {
                options.AddPolicy("default", policy =>
                {
                    policy.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            System.Reflection.Assembly[] assemblies = { typeof(SendMessageModelProfile).Assembly, typeof(Startup).Assembly };
            services.AddAutoMapper(assemblies);
            services.AddMediatR(typeof(SendMessageCommand).Assembly);
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Styles")),
                RequestPath = "/styles",
            });

            app.UseCustomExceptionHandler();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("default");

            app.UseIdentityServer();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
