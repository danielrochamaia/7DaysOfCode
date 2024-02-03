namespace _7DaysOfCode.Entities
{
    public class Person
    {
        public string Name { get; set; }

        public List<string> Pets { get; set; }

        public Person(string name)
        {
            Name = name;
            Pets = new List<string>();
        }

        public string AddPet(string name)
        {
            if(Pets.Contains(name))
            {
                Console.WriteLine("Você já adotou esse mascote! Escolha um diferente.");
            }

            Pets.Add(name);
            return "Mascote adotado com sucesso!";
        }
    }
}
