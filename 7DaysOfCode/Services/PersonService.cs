using _7DaysOfCode.Entities;

namespace _7DaysOfCode.Services
{
    public static class PersonService
    {
        public static void ShowPets(Person person)
        {
            Utils.PrintHeader("SEUS MASCOTES");

            var pets = person.Pets;

            if (pets.Count > 0)
            {
                pets.ForEach(Console.WriteLine);
            }
            else
            {
                Console.WriteLine("Você não tem nenhum mascote ainda.");
            }

            TomagotchiService.MainMenu(person);
        }

        public static void AdoptSelectedPet(Person person, string chosenPet)
        {
            Utils.PrintHeader("");
            Console.WriteLine(person.AddPet(chosenPet));
            TomagotchiService.MainMenu(person);
        }
    }
}
