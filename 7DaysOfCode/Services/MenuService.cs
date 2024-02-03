using _7DaysOfCode.Entities;

namespace _7DaysOfCode.Services
{
    public static class MenuService
    {
        public static void MainMenu(Person person)
        {
            var mainMenu = new Dictionary<string, string> { { "1", "Adotar um mascote virtual" }, { "2", "Ver seus mascotes" }, { "3", "Sair" } };

            Utils.PrintHeader("MENU");
            Console.WriteLine($"{person.Name}, o que você deseja?");
            Utils.ShowOptions(mainMenu);
            Console.Write("Escolha: ");
            var menuOption = Console.ReadLine();

            switch (menuOption)
            {
                case "1":
                    PetService.SelectingPetToAdopt(person);
                    break;
                case "2":
                    PersonService.ShowPets(person);
                    break;
                default:
                    Console.WriteLine("\nAté mais!");
                    break;
            }
        }

        public static void InternMenu(Person person, string chosenPet)
        {
            var internMenu = new Dictionary<string, string> { { "1", $"Saber mais sobre {chosenPet}" }, { "2", $"Adotar {chosenPet}" }, { "3", "Voltar" } };
            
            Utils.PrintHeader("");
            Console.WriteLine("Você deseja: ");
            Utils.ShowOptions(internMenu);
            Console.Write("Escolha: ");
            var menuOption = Console.ReadLine();

            switch (menuOption)
            {
                case "1":
                    PetService.ShowSelectedPetInfo(person, chosenPet);
                    break;
                case "2":
                    PersonService.AdoptSelectedPet(person, chosenPet);
                    break;
                default:
                    MainMenu(person);
                    break;
            }
        }
    }
}
