using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using IdentityModel.Client;
using Newtonsoft.Json;

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

            client.SetBearerToken(response.AccessToken);

            var comstomInfo = new StringContent(JsonConvert.SerializeObject(
                    new { Id = 10, FirstName = "Moh", LastName = "bay" }),
                    Encoding.UTF8,"application/json") ;

            var postresponse=client.PostAsync("http://localhost:35554/api/Customers", comstomInfo);
            var getresponse = client.GetAsync("http://localhost:35554/api/Customers");

            Console.WriteLine(await getresponse.Result.Content.ReadAsStringAsync());
            Console.ReadLine();
        }
    }
}
