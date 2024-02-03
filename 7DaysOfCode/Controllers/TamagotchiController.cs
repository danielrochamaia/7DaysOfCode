using _7DaysOfCode.Entities;
using _7DaysOfCode.Services;

namespace _7DaysOfCode.Controllers
{
    internal class TamagotchiController
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Tamagotchi\n");
            Console.Write($"Qual é o seu nome? ");
            var name = Console.ReadLine();
            var person = new Person(name);
            MenuService.MainMenu(person);
        }
    }
}
