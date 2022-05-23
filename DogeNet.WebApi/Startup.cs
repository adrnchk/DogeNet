// <copyright file="Startup.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.WebApi
{
    using System;
    using System.Collections.Generic;
    using DogeNet.BLL.Extentions;
    using DogeNet.BLL.Features.Messages.SendMessage;
    using DogeNet.BLL.Middleware;
    using DogeNet.DAL;
    using DogeNet.WebApi.Hubs;
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
    using Microsoft.IdentityModel.Tokens;
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, config =>
                {
                    config.Authority = this.AppConfiguration.GetValue<string>("Services:IdentityServer");
                    config.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,
                    };
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

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .SetIsOriginAllowed((host) => true) //allow all connections (including Signalr)
                    );
            });
            services.AddSignalR();

            services.AddControllers(options => options.Filters.Add<ValidationFilterMiddleware>())
                .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true)
                .AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining<ExceptionHandlerMiddleware>())
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddTransient<IValidator<SendMessageModel>, SendMessageValidator>();
            services.AddAutoMapper(typeof(SendMessageModelProfile).Assembly);
            services.AddMediatR(typeof(SendMessageCommand).Assembly);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "DogeNet.WebApi v1"));
            }

            app.UseCustomExceptionHandler();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<CommunicationHub>("/chat");
            });
        }
    }
}
