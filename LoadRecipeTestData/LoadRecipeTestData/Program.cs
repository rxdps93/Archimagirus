using System.Text;
using LoadRecipeTestData.DataModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LoadRecipeTestData
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            ConfigurationHelper.SetupConfiguration();
            if (!ConfigurationHelper.ValidateConfigurations())
            {
                Console.WriteLine("Invalid configuration");
                return;
            }

            Console.WriteLine("Loading recipe data");
            LoadData(ConfigurationHelper.Configuration["FilePaths:RecipesJsonPath"]!);
        }

        private static void LoadData(string path)
        {
            dynamic json = JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(path))!;
            foreach (dynamic r in json)
            {
                var recipe = new Recipe
                {
                    Name = r.Name,
                    Description = r.Description,
                    Instructions = string.Join('|', r.Instructions),
                    Source = r.Source,
                };

                var ingredients = new List<Ingredient>();
                foreach (var i in r.Ingredients)
                {

                }

                // Console.WriteLine($"\t{recipe.Name}\n\t\t{recipe.Description}\n\t\t{recipe.Instructions}\n\t\t{recipe.Source}");
            }
        }
    }
}