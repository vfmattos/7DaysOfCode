using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PokeAPI.Models;
using PokeAPI.Services;
using RestSharp;
using System.Globalization;

namespace PokeAPI
{
    internal class Program
    {


        static async Task Main(string[] args)
        {
            PokeApiService service = new PokeApiService();

            service.MostrarEspecies();

            service.EscolherPokemon();



        }

    }
}