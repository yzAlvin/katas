using IdentityModel.Client;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace hplussport_console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();

            var discoveryDocument = await client.GetDiscoveryDocumentAsync(
                "http://localhost:5002"
            );

            var tokenResponse = await
            client.RequestClientCredentialsTokenAsync(
                new ClientCredentialsTokenRequest
                {
                    Address = discoveryDocument.TokenEndpoint,
                    ClientId = "client",
                    ClientSecret = "H+ Sport",
                    Scope = "hps-api"
                }
            );
            Console.WriteLine($"Token: {tokenResponse.AccessToken}");

        }
    }
}
