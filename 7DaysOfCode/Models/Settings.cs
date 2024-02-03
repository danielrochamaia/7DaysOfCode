using Microsoft.Extensions.Configuration;

namespace _7DaysOfCode.Models
{
    public class Settings
    {
        public Dictionary<string, string> Pokemons { get; set; }

        public string BasePokemonApi {  get; set; }

        public Settings GetSettings()
        {
            var directory = Directory.GetCurrentDirectory().Split("bin").FirstOrDefault();
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(directory)
                .AddJsonFile("appsettings.json")
                .Build();

            return configuration.GetSection("Settings").Get<Settings>();
        }
    }
}
