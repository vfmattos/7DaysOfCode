using PokeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PokeAPI.Services
{
    internal class Menu
    {

        public string Nome { get; set; }
        public int Escolha { get; set; }

        public Menu(string nome) {  Nome = nome; }

        public int TelaInicial()
        {
            Console.WriteLine("-------------- MENU --------------");
            Console.WriteLine($"Olá {Nome}! O que deseja fazer?");
            Console.WriteLine("1 - Adotar um mascote");
            Console.WriteLine("2 - Ver seus mascotes");
            Console.WriteLine("3 - Sair");

            Escolha = int.Parse(Console.ReadLine());

            return Escolha;
        }

        public int AdotarMascote()
        {
            Console.WriteLine("-------------- ADOTAR MASCOTE --------------");
            Console.WriteLine($"{Nome}, Escolha uma espécie: ");
            Escolha = int.Parse(Console.ReadLine());

            return Escolha;

        }

        public int Acao(Mascote pokemon)
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine($"{Nome}, Você deseja: ");
            Console.WriteLine($"1 - Saber mais sobre o {pokemon.Name}");
            Console.WriteLine($"2 - Adotar {pokemon.Name} ");
            Console.WriteLine($"3 - Voltar ");

            Escolha = int.Parse(Console.ReadLine());

            return Escolha;
        }

    }
}
