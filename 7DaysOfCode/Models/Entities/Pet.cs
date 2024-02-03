using _7DaysOfCode.Services;

namespace _7DaysOfCode.Models.Entities
{
    public class Pet
    {
        public enum Status { HUNGER, MOOD, THIRST, SLEEP }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public int HungerLevel { get; set; }

        public int MoodLevel { get; set; }

        public int ThirstLevel { get; set; }

        public int Sleeplevel { get; set; }

        public void GetPetStatus()
        {
            Utils.PrintHeader("Status");
            Console.WriteLine($"Nome do pet: {Name}");
            Console.WriteLine($"Altura: {Height}");
            Console.WriteLine($"Peso: {Weight}");
            PrintStatus();
        }

        public void ToPlay()
        {
            HungerLevel -= 1;
            MoodLevel += 7;
            ThirstLevel -= 1;
            Sleeplevel -= 1;
            AdjustMinAndMaxStatus();
            Console.Write("Brincando com o pet");
            Utils.PrintWaiting();
            PrintStatus();
            Console.ResetColor();
        }

        public void ToFeed()
        {
            HungerLevel += 7;
            MoodLevel -= 1;
            ThirstLevel -= 1;
            Sleeplevel -= 1;
            AdjustMinAndMaxStatus();
            Console.Write("Dando ração");
            Utils.PrintWaiting();
            PrintStatus();
            Console.ResetColor();
        }

        public void GiveWater()
        {
            MoodLevel -= 1;
            ThirstLevel += 7;
            AdjustMinAndMaxStatus();
            Console.Write("Dando água");
            Utils.PrintWaiting();
            PrintStatus();
            Console.ResetColor();
        }

        public void ToSleep()
        {
            HungerLevel -= 2;
            MoodLevel -= 2;
            ThirstLevel -= 2;
            Sleeplevel += 10;
            AdjustMinAndMaxStatus();
            Console.Write("Botando pra dormir");
            Utils.PrintWaiting();
            PrintStatus();
            Console.ResetColor();
        }

        private string GetStatusLevel(Status status)
        {
            int level = default;
            string statusName = default;
            switch (status)
            {
                case Status.HUNGER:
                    level = HungerLevel;
                    statusName = "fome";
                    break;
                case Status.MOOD:
                    level = MoodLevel;
                    statusName = "tédio";
                    break;
                case Status.THIRST:
                    level = ThirstLevel;
                    statusName = "sede";
                    break;
                case Status.SLEEP:
                    level = Sleeplevel;
                    statusName = "sono";
                    break;
            }

            if (level < 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return $"está com {statusName}";
            }

            if (level >= 3 && level <= 7)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                return $"está +/- com {statusName}";
            }
            Console.ForegroundColor = ConsoleColor.Green;
            return $"está sem {statusName}";
        }

        private void AdjustMinAndMaxStatus()
        {
            if (HungerLevel < 0)
            {
                HungerLevel = 0;
            }

            if (MoodLevel > 10)
            {
                MoodLevel = 10;
            }

            if (ThirstLevel < 0)
            {
                ThirstLevel = 0;
            }

            if (Sleeplevel < 0)
            {
                Sleeplevel = 0;
            }
        }

        private void PrintStatus()
        {
            Console.WriteLine($"{Name} {GetStatusLevel(Status.HUNGER)}");
            Console.ResetColor();
            Console.WriteLine($"{Name} {GetStatusLevel(Status.THIRST)}");
            Console.ResetColor();
            Console.WriteLine($"{Name} {GetStatusLevel(Status.MOOD)}");
            Console.ResetColor();
            Console.WriteLine($"{Name} {GetStatusLevel(Status.SLEEP)}");
            Console.ResetColor();
        }
    }
}
