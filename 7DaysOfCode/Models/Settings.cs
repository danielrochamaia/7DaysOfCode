using Microsoft.Extensions.Configuration;

namespace _7DaysOfCode.Models
{
    public class Settings
    {
        public Dictionary<string, string> Pokemons { get; set; }

        public string BasePokemonApi {  get; set; }

        public Settings GetSettings()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile(@"C:\Users\danro\source\repos\Git\7DaysOfCode\7DaysOfCode\appsettings.json")
                .Build();

            return configuration.GetSection("Settings").Get<Settings>();
        }
    }
}
