using IdentityModel;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hplussport_identityserver
{
    public class Config
    {
        public static IEnumerable<ApiResource> Apis
        {
            get
            {
                return new List<ApiResource>
                {
                new ApiResource("hps-api", "H+ Sport API")
                };
            }
        }

        public static IEnumerable<Client> Clients
        {
            get
            {
                return new List<Client>
                {
                    new Client
                    {
                        ClientId = "client",
                        AllowedScopes = { "hps-api" },

                        AllowedGrantTypes = GrantTypes.ClientCredentials,
                        ClientSecrets =
                        {
                            new Secret("H+ Sport".Sha256())
                        }
                    }
                };
            }
        }

        public static IEnumerable<ApiScope> Scopes
        {
            get
            {
                return new List<ApiScope>
                {
                    new ApiScope("hps-api")
                };
            }
        }
    }
}
