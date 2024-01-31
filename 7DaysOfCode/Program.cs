using _7DaysOfCode.Entities;
using RestSharp;
using System.Text.Json;

internal class Program
{
    private static void Main(string[] args)
    {
        var pokemons = new Dictionary<int, string> { { 1, "pikachu" }, { 2, "bulbasaur" }, { 3, "charmander" }, { 4, "meowth" }, { 5, "zapdos" }, { 6, "mewtwo" }, { 0, "encerrar" } };

        Console.WriteLine("Pokemons disponíveis para consulta: ");

        foreach (var p in pokemons)
        {
            Console.WriteLine($"{p.Key} - {p.Value}");
        }

        while (true)
        {
            Console.Write("\nInsira o id do pokemon para verificar seus atributos: ");
            var pokemonId = Console.ReadLine();
            if(pokemonId == "0")
            {
                Console.WriteLine("Até mais!");
                break;
            }

            string pokemonEscolhido = default;

            try
            {
                pokemonEscolhido = pokemons[int.Parse(pokemonId)];
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Id não encontrado.");
            }

            if(pokemonEscolhido != default)
            {
                var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{pokemonEscolhido}");
                var request = new RestRequest("", Method.Get);
                var response = client.Execute(request);
                var pokemon = JsonSerializer.Deserialize<Pokemon>(response.Content);

                Console.WriteLine($"Nome pokemon: {pokemon.forms.FirstOrDefault().name}");
                Console.WriteLine($"Altura: {pokemon.height}");
                Console.WriteLine($"Peso: {pokemon.weight}");
                Console.WriteLine($"Habilidades:");
                pokemon.abilities.ForEach(a => Console.WriteLine(a.ability.name.ToUpper()));
            }
        }
    }
}