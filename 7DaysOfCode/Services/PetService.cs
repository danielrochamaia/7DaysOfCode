using _7DaysOfCode.Entities;
using _7DaysOfCode.Models.Entities;
using RestSharp;
using System;
using System.Text.Json;

namespace _7DaysOfCode.Services
{
    public static class PetService
    {
        public static void ShowSelectedPetInfo(Person person, string chosenPet)
        {
            Utils.PrintHeader("");
            var pokemon = GetPokemonInfo(chosenPet);

            Console.WriteLine($"Nome pokemon: {pokemon.forms.FirstOrDefault().name}");
            Console.WriteLine($"Altura: {pokemon.height}");
            Console.WriteLine($"Peso: {pokemon.weight}");
            Console.WriteLine($"Habilidades:");
            pokemon.abilities.ForEach(a => Console.WriteLine(a.ability.name.ToUpper()));
            MenuService.InternMenu(person, chosenPet);
        }

        public static void SelectingPetToAdopt(Person person)
        {
            var pokemons = Utils.GetSettings().Pokemons;
            Utils.PrintHeader("ADOTAR UM MASCOTE");
            Console.WriteLine("Escolha uma espécie: ");
            Utils.ShowOptions(pokemons);
            Console.Write("Escolha: ");
            var chosenPet = pokemons[Console.ReadLine()];

            MenuService.InternMenu(person, chosenPet);
        }

        public static void SelectPetToCare(Person person, Pet pet)
        {
            Utils.PrintHeader("");
            var menuInteragir = new Dictionary<string, string>
            {
                { "1", $"Alimentar o {pet.Name}" },
                { "2", $"Dar água para o {pet.Name}" },
                { "3", $"Brincar com o {pet.Name}" },
                { "4", $"Botar o {pet.Name} para dormir" },
                { "5", "Voltar" }
            };
            Utils.ShowOptions(menuInteragir);
            Utils.PrintHeader("");
            Console.Write("Escolha: ");
            var menuOption = Console.ReadLine();

            switch (menuOption)
            {
                case "1":
                    pet.ToFeed();
                    SelectPetToCare(person, pet);
                    break;
                case "2":
                    pet.GiveWater();
                    SelectPetToCare(person, pet);
                    break;
                case "3":
                    pet.ToPlay();
                    SelectPetToCare(person, pet);
                    break;
                case "4":
                    pet.ToSleep();
                    SelectPetToCare(person, pet);
                    break;
                default:
                    MenuService.MainMenu(person);
                    break;
            }

        }

        public static Pokemon GetPokemonInfo(string chosenPet)
        {
            var client = new RestClient($"{Utils.GetSettings().BasePokemonApi}{chosenPet}");
            var request = new RestRequest("", Method.Get);
            var response = client.Execute(request);
            return JsonSerializer.Deserialize<Pokemon>(response.Content);
        }
    }
}
