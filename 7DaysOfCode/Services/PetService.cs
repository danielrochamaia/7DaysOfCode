using _7DaysOfCode.Entities;
using RestSharp;
using System.Text.Json;

namespace _7DaysOfCode.Services
{
    public static class PetService
    {
        public static void ShowSelectedPetInfo(Person person, string chosenPet)
        {
            Utils.PrintHeader("");
            var client = new RestClient($"{Utils.GetSettings().BasePokemonApi}{chosenPet}");
            var request = new RestRequest("", Method.Get);
            var response = client.Execute(request);
            var pokemon = JsonSerializer.Deserialize<Pokemon>(response.Content);

            Console.WriteLine($"Nome pokemon: {pokemon.forms.FirstOrDefault().name}");
            Console.WriteLine($"Altura: {pokemon.height}");
            Console.WriteLine($"Peso: {pokemon.weight}");
            Console.WriteLine($"Habilidades:");
            pokemon.abilities.ForEach(a => Console.WriteLine(a.ability.name.ToUpper()));
            TomagotchiService.InternMenu(person, chosenPet);
        }

        public static void SelectingPetToAdopt(Person person)
        {
            var pokemons = Utils.GetSettings().Pokemons;
            Utils.PrintHeader("ADOTAR UM MASCOTE");
            Console.WriteLine("Escolha uma espécie: ");
            Utils.ShowOptions(pokemons);
            Console.Write("Escolha: ");
            var chosenPet = pokemons[Console.ReadLine()];

            TomagotchiService.InternMenu(person, chosenPet);
        }
    }
}
