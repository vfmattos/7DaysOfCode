using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PokeAPI.Models;
using RestSharp;
using System.Globalization;

namespace PokeAPI
{
    internal class Program
    {


        static async Task Main(string[] args)
        {
            try
            {

                var options = new RestClientOptions("https://pokeapi.co")
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);
                var request = new RestRequest("/api/v2/pokemon/", Method.Get);
                RestResponse response = await client.ExecuteAsync(request);

                var pokemon = JsonConvert.DeserializeObject<Pokemon>(response.Content);

                for (int i = 0; i < pokemon.Results.Count; i++)
                {
                    await Console.Out.WriteLineAsync($"{i + 1} - {pokemon.Results[i].Name}");
                }

                int id;

                while (true)
                {

                    await Console.Out.WriteAsync("\nDigite o id do pokemon: ");

                    if (int.TryParse(Console.ReadLine(), out id) && id >= 1 && id <= pokemon.Results.Count)
                    {
                        break;
                    }
                    await Console.Out.WriteLineAsync("Id inválido!");
                }

                request = new RestRequest($"/api/v2/pokemon/{id}", Method.Get);
                response = await client.ExecuteAsync(request);

                var pokemonEscolhido = JsonConvert.DeserializeObject<Mascote>(response.Content);

                await Console.Out.WriteLineAsync($"Nome pokemon: {pokemonEscolhido.Name} \nAltura: {pokemonEscolhido.Height} \nPeso: {pokemonEscolhido.Weight} \nHabilidades:");

                foreach(var ability in pokemonEscolhido.Abilities) {

                    await Console.Out.WriteLineAsync(ability.AbilityAbility.Name);

                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }



        }

    }
}