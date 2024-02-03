using _7DaysOfCode.Models.Entities;

namespace _7DaysOfCode.Entities
{
    public class Person
    {
        public string Name { get; set; }

        public List<Pet> Pets { get; set; }

        public Person(string name)
        {
            Name = name;
            Pets = new List<Pet>();
        }

        public string AddPet(Pet pet)
        {
            //if(Pets.Contains(pet))
            //{
            //    Console.WriteLine("Você já adotou esse mascote! Escolha um diferente.");
            //}

            Pets.Add(pet);
            return "Mascote adotado com sucesso!";
        }
    }
}
