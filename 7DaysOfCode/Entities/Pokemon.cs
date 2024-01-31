using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7DaysOfCode.Entities
{
    internal class Pokemon
    {
        public List<Ability> abilities {  get; set; }

        public List<Form> forms {  get; set; }

        public int height { get; set; }

        public int weight { get; set; }
    }
}
