using Newtonsoft.Json;
using PokeAPI.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeAPI.Services
{
    internal class PokeApiService
    {
        public RestClientOptions options { get; set; }
        public RestClient client { get; set; }
        public RestRequest request { get; set; }
        public RestResponse response { get; set; }
        public Pokemon pokemon { get; set; }

        public void MostrarEspecies()
        {

            options = new RestClientOptions("https://pokeapi.co")
            {
                MaxTimeout = -1,
            };
            client = new RestClient(options);
            request = new RestRequest("/api/v2/pokemon/", Method.Get);
            response = client.Execute(request);

            pokemon = JsonConvert.DeserializeObject<Pokemon>(response.Content);

            for (int i = 0; i < pokemon.Results.Count; i++)
            {
                Console.Out.WriteLine($"{i + 1} - {pokemon.Results[i].Name}");
            }

        }

        public void EscolherPokemon()
        {

            Console.Write("\nDigite um id: ");

            int id;

            while (true)
            {

                if (int.TryParse(Console.ReadLine(), out id) && id >= 1 && id <= pokemon.Results.Count)
                {
                    break;
                }
                Console.WriteLine("Id inválido!");
            }

            request = new RestRequest($"/api/v2/pokemon/{id}", Method.Get);
            response = client.Execute(request);

            var pokemonEscolhido = JsonConvert.DeserializeObject<Mascote>(response.Content);

            Console.WriteLine($"\nNome pokemon: {pokemonEscolhido.Name} \nAltura: {pokemonEscolhido.Height} \nPeso: {pokemonEscolhido.Weight} \nHabilidades:");

            foreach (var ability in pokemonEscolhido.Abilities)
            {

                Console.WriteLine(ability.AbilityAbility.Name);

            }

        }

    }
}
