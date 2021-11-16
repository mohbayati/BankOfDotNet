using System;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;

namespace BankOfDotNet.ConsoleClient
{
    class Program
    {
        static void Main(string[] args) => MainAsync().GetAwaiter().GetResult();

        private static async Task MainAsync()
        {
            //discover all endpoint using metadata of identity server
            var client = new HttpClient();

            //var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5000");
            //if (disco.IsError) throw new Exception(disco.Error);

            //var tokenClient = new TokenClient(disco.TokenEndpoint, new TokenClientOptions { ClientId="client",ClientSecret="secret"})

            var response = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = "http://localhost:5000/connect/token",

                ClientId = "client",
                ClientSecret = "secret",
                Scope = "bankOfDotNetApi"
            });

            Console.WriteLine(response.AccessToken);
            Console.ReadLine();
        }
    }
}
