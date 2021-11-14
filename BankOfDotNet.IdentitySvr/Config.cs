using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankOfDotNet.IdentitySvr
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetAllApiResources()
        {
            return new List<ApiResource> { new ApiResource("bankOfDotNetApi", "Custome Api for BankOfDotNet") };
        }
        public static IEnumerable<ApiScope> GetAllApiScope()
        {
            return new List<ApiScope> { new ApiScope("bankOfDotNetApi", "Custome Api for BankOfDotNet") };
        }
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId="client",
                    AllowedGrantTypes= GrantTypes.ClientCredentials,
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = new List<string>{ "bankOfDotNetApi" }
                }
            };
        }
    }
}
