using _7DaysOfCode.Entities;
using RestSharp;
using System;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Tamagotchi\n");
        Console.Write("Qual é o seu nome? ");
        var name = Console.ReadLine();
        var person = new Person(name);

        MainMenu(person);

    }

    private static void MainMenu(Person person)
    {
        var menuPrincipal = new Dictionary<string, string> { { "1", "Adotar um mascote virtual" }, { "2", "Ver seus mascotes" }, { "3", "Sair" } };

        PrintHeader("MENU");
        Console.WriteLine($"{person.Name}, o que você deseja?");
        ShowOptions(menuPrincipal);
        Console.Write("Escolha: ");
        var menuOption = Console.ReadLine();

        switch (menuOption)
        {
            case "1":
                AdoptAPet(person);
                break;
            case "2":
                ShowPets(person);
                break;
            default:
                Console.WriteLine("\nAté mais!");
                break;
        }
    }

    private static void ShowPetInfo(Person person, string chosenPet)
    {
        PrintHeader("");
        var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{chosenPet}");
        var request = new RestRequest("", Method.Get);
        var response = client.Execute(request);
        var pokemon = JsonSerializer.Deserialize<Pokemon>(response.Content);

        Console.WriteLine($"Nome pokemon: {pokemon.forms.FirstOrDefault().name}");
        Console.WriteLine($"Altura: {pokemon.height}");
        Console.WriteLine($"Peso: {pokemon.weight}");
        Console.WriteLine($"Habilidades:");
        pokemon.abilities.ForEach(a => Console.WriteLine(a.ability.name.ToUpper()));
        MenuInterno(person, chosenPet);
    }

    private static void AdoptAPet(Person person)
    {
        var pokemons = new Dictionary<string, string> { { "1", "pikachu" }, { "2", "bulbasaur" }, { "3", "charmander" }, { "4", "meowth" }, { "5", "zapdos" }, { "6", "mewtwo" } };
        PrintHeader("ADOTAR UM MASCOTE");
        Console.WriteLine("Escolha uma espécie: ");
        ShowOptions(pokemons);
        Console.Write("Escolha: ");
        var chosenPet = pokemons[Console.ReadLine()];

        MenuInterno(person, chosenPet);
    }

    private static void MenuInterno(Person person, string chosenPet)
    {
        PrintHeader("");
        var menuInterno = CreateDictMenuInterno(chosenPet);
        Console.WriteLine("Você deseja: ");
        ShowOptions(menuInterno);
        Console.Write("Escolha: ");
        var escolha = Console.ReadLine();

        switch (escolha)
        {
            case "1":
                ShowPetInfo(person, chosenPet);
                break;
            case "2":
                AdotarPet(person, chosenPet);
                break;
            default:
                MainMenu(person);
                break;
        }
    }

    private static void AdotarPet(Person person, string chosenPet)
    {
        PrintHeader("");
        Console.WriteLine(person.AddPet(chosenPet));
        MainMenu(person);
    }

    private static void ShowPets(Person person)
    {
        PrintHeader("SEUS MASCOTES");

        var pets = person.Pets;

        if (pets.Count > 0)
        {
            pets.ForEach(Console.WriteLine);
        }
        else
        {
            Console.WriteLine("Você não tem nenhum mascote ainda.");
        }

        MainMenu(person);
    }

    private static Dictionary<string, string> CreateDictMenuInterno(string chosenPet)
        => new Dictionary<string, string> { { "1", $"Saber mais sobre {chosenPet}" }, { "2", $"Adotar {chosenPet}" }, { "3", "Voltar" } };

    private static void ShowOptions(Dictionary<string, string> dict)
    {
        foreach (var i in dict)
        {
            Console.WriteLine($"{i.Key} - {i.Value}");
        }
    }

    private static void PrintHeader(string header)
    {
        Thread.Sleep(500);
        Console.Write(".");
        Thread.Sleep(500);
        Console.Write(".");
        Thread.Sleep(500);
        Console.Write(".\n");

        var len = (64 - header.Length) / 2;


        var hyphens = new StringBuilder();
        for(var i = 0; i < len; i++)
        {
            hyphens.Append('-');
        }

        if (header != "")
        {
            Console.WriteLine($"{hyphens} {header} {hyphens}");
        }
        else
        {
            Console.WriteLine($"------------------------------------------------------------------");
        }
    }
}