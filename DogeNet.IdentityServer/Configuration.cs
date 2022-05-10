// <copyright file="Configuration.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.IdentityServer
{
    using System.Collections.Generic;
    using IdentityModel;
    using IdentityServer4;
    using IdentityServer4.Models;
    using Microsoft.Extensions.Configuration;

    public static class Configuration
    {
        public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope>
        {
            new ApiScope(Startup.StaticConfig.GetValue<string>("Scopes:WebApi:Name")),
        };

        public static IEnumerable<IdentityResource> IdentityResources => new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };

        public static IEnumerable<ApiResource> ApiResources =>
        new List<ApiResource>
        {
            new ApiResource(Startup.StaticConfig.GetValue<string>("Scopes:WebApi:Name"), new[] { JwtClaimTypes.Name })
            {
                Scopes = { Startup.StaticConfig.GetValue<string>("Scopes:WebApi:Name") },
            },
        };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "client_id_swagger",
                    ClientSecrets = { new Secret("client_secret_swagger".ToSha256()) },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowedCorsOrigins = { "https://localhost:7001" },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        Startup.StaticConfig.GetValue<string>("Scopes:WebApi:Name"),
                    },
                },

                new Client
                {
                    ClientId = Startup.StaticConfig.GetValue<string>("Clients:WebApi:Id"),

                    ClientName = Startup.StaticConfig.GetValue<string>("Clients:WebApi:Name"),

                    ClientSecrets =
                    {
                        new Secret(Startup.StaticConfig.GetValue<string>("Clients:WebApi:Secret").ToSha256()),
                    },

                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        Startup.StaticConfig.GetValue<string>("Scopes:WebApi:Name"),
                    },

                    AllowAccessTokensViaBrowser = true,
                },
                new Client
                {
                    ClientId = Startup.StaticConfig.GetValue<string>("Clients:WebApp:Id"),

                    ClientName = Startup.StaticConfig.GetValue<string>("Clients:WebApp:Name"),

                    RequireClientSecret = false,
                    AllowedGrantTypes = GrantTypes.Code,

                    RedirectUris = { "http://localhost:4200" },
                    PostLogoutRedirectUris = { "http://localhost:4200" },
                    AllowedCorsOrigins = { "http://localhost:4200" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        Startup.StaticConfig.GetValue<string>("Scopes:WebApi:Name"),
                    },

                    AccessTokenLifetime = 1,

                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,
                },
            };
    }
}
