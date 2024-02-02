using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7DaysOfCode.Entities
{
    internal class Person
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
