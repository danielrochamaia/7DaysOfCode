using _7DaysOfCode.Entities;
using _7DaysOfCode.Models.Entities;

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
                pets.ForEach(p =>
                {
                    Console.WriteLine($"{p.Id} - {p.Name}");
                });
            }
            else
            {
                Console.WriteLine("Você não tem nenhum mascote ainda.");
                MenuService.MainMenu(person);
            }

            Console.Write("Escolha um pet para interagir: ");
            var chosenPetId = Console.ReadLine();
            var chosenPetObject = person.Pets.Where(p => p.Id.ToString().Equals(chosenPetId)).FirstOrDefault();
            chosenPetObject.GetPetStatus();
            PetService.SelectPetToCare(person, chosenPetObject);
        }

        public static void AdoptSelectedPet(Person person, string chosenPet)
        {
            Utils.PrintHeader("");
            var chonsenPetInfo = PetService.GetPokemonInfo(chosenPet);
            var newPet = new Pet
            {   
                Id = person.Pets.Count+1,
                Name = chonsenPetInfo.forms.FirstOrDefault().name,
                Height = chonsenPetInfo.height,
                Weight = chonsenPetInfo.weight,
                HungerLevel = Utils.RandomStartLevel(),
                MoodLevel = Utils.RandomStartLevel(),
                ThirstLevel = Utils.RandomStartLevel(),
                Sleeplevel = Utils.RandomStartLevel()
            };
            Console.WriteLine(person.AddPet(newPet));
            MenuService.MainMenu(person);
        }
    }
}
