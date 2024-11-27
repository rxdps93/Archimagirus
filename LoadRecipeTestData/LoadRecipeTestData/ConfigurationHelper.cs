using Microsoft.Extensions.Configuration;

namespace LoadRecipeTestData
{
    public static class ConfigurationHelper
    {
        public static IConfigurationRoot Configuration { get; private set; }
        public static string SqlConnectionString { get; private set; }

        public static void SetupConfiguration()
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();

            SqlConnectionString = Configuration.GetConnectionString("SqlConnectionString");
        }

        public static bool ValidateConfigurations()
        {
            var configurationKeys = new List<string>
            {
                "FilePaths:RecipesJsonPath",
                "ConnectionStrings:SqlConnectionString"
            };

            if (configurationKeys.Any(configKey => !ConfigPathIsValid(configKey)))
            {
                Console.WriteLine("Cannot continue; invalid config.");
                return false;
            }

            return true;
        }

        private static bool ConfigPathIsValid(string configName)
        {
            string path;

            if (configName.StartsWith("FilePaths:"))
            {
                path = Configuration[configName];
                if (!File.Exists(path))
                {
                    Console.WriteLine($"File {path} for {configName} not found.");
                    return false;
                }
            }
            else if (configName.StartsWith("ConnectionStrings:"))
            {
                path = Configuration[configName];
            }
            else
            {
                path = Configuration[configName];
                if (string.IsNullOrWhiteSpace(path))
                {
                    Console.WriteLine($"{configName} configuration is missing or empty.");
                    return false;
                }
                return true;
            }

            if (string.IsNullOrEmpty(path))
            {
                Console.WriteLine($"{configName} configuration is missing.");
                return false;
            }

            return true;
        }
    }
}