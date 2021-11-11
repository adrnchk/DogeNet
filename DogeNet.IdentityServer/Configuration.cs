using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogeNet.IdentityServer
{
    public static class Configuration
    {
        public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope>
        {
            new ApiScope("DogeNetWebAPI", "Web API")
        };

        public static IEnumerable<IdentityResource> IdentityResources => new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };
        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("DogeNetWebAPI", "Web API", new []
                    { JwtClaimTypes.Name})
                {
                    Scopes = { "DogeNetWebAPI" }
                }
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "DogeNet-web-api",
                    ClientName = "DogeNet Web Api",
                    
                    ClientSecrets={new Secret("1234".ToSha256())},

                    AllowedGrantTypes = GrantTypes.Code,
                    
                    AllowedCorsOrigins = { "https://localhost:7001", "http://localhost:7000" },

                    RedirectUris = { "https://localhost:7001" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "DogeNetWebAPI"
                    },
                    AllowAccessTokensViaBrowser = true
                },
                new Client
                {
                    ClientId = "client_id_swagger",
                    ClientSecrets = { new Secret("client_secret_swagger".ToSha256()) },
                    AllowedGrantTypes =  GrantTypes.ResourceOwnerPassword,
                    AllowedCorsOrigins = { "https://localhost:7001" },
                    AllowedScopes =
                    {
                        "DogeNetWebAPI",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                },
                new Client
                {
                    ClientId = "DogeNet-web-app",
                    ClientName = "DogeNet Client",
                    ClientSecrets={new Secret("client_secret".ToSha256())},

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                                        
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "DogeNetWebAPI"
                    },
                    AllowAccessTokensViaBrowser = true
                }
            };
    }
}
