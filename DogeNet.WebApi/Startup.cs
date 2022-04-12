// <copyright file="Startup.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.WebApi
{
    using System;
    using System.Collections.Generic;
    using DogeNet.BLL.Features.Messages.SendMessage;
    using DogeNet.BLL.Services.Implementations;
    using DogeNet.BLL.Services.Interfaces;
    using DogeNet.DAL;
    using FluentValidation;
    using FluentValidation.AspNetCore;
    using IdentityServer4.AccessTokenValidation;
    using MediatR;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.AppConfiguration = configuration;
        }

        public IConfiguration AppConfiguration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddIdentityServerAuthentication(options =>
                {
                    options.ApiName = "DogeNetWebAPI";
                    options.Authority = this.AppConfiguration.GetValue<string>("Services:IdentityServer");
                    options.RequireHttpsMetadata = false;
                });

            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        Password = new OpenApiOAuthFlow
                        {
                            TokenUrl = new Uri("https://localhost:10001/connect/token"),
                            Scopes = new Dictionary<string, string>
                            {
                                {
                                    this.AppConfiguration.GetValue<string>("Scopes:WebApi:Name"),
                                    this.AppConfiguration.GetValue<string>("Scopes:WebApi:Description")
                                },
                            },
                        },
                    },
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "oauth2",
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    },
                });
            });

            services.AddAuthorization();

            var connectionString = this.AppConfiguration.GetConnectionString(nameof(DBContext));
            services.AddDbContext<DBContext>(options => options.UseSqlServer(connectionString));
            services.AddIdentity<IdentityUser, IdentityRole>(config =>
                {
                    config.Password.RequireDigit = false;
                    config.Password.RequireLowercase = false;
                    config.Password.RequireNonAlphanumeric = false;
                    config.Password.RequireUppercase = false;
                    config.Password.RequiredLength = 4;
                })
                .AddEntityFrameworkStores<DBContext>();

            services.AddCors();

            services.AddControllers().AddFluentValidation().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddTransient<IValidator<SendMessageModel>, SendMessageValidator>();
            services.AddAutoMapper(typeof(SendMessageModelProfile).Assembly);
            services.AddMediatR(typeof(SendMessageCommand).Assembly);
            services.AddScoped<IUserManagerService, UserManagerService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "DogeNet.WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
