using RestSharp;

namespace PokeAPI
{
    internal class Program
    {


        static async Task Main(string[] args)
        {

            var options = new RestClientOptions("https://pokeapi.co")
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/api/v2/pokemon/", Method.Get);
            RestResponse response = await client.ExecuteAsync(request);
            await Console.Out.WriteLineAsync(response.Content);

        }

    }
}