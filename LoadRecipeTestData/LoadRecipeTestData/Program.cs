using System.Collections.ObjectModel;
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
                var recipe = new RecipeLoad
                {
                    RecipeName = r.Name,
                    Description = r.Description,
                    Instructions = string.Join('|', r.Instructions),
                    Source = r.Source,
                    Ingredients = new List<(string, decimal, string, string)>(),
                    Tags = new List<string>(),
                };

                foreach (var t in r.Tags)
                {
                    recipe.Tags.Add(t.ToString());
                }

                foreach (var i in r.Ingredients)
                {
                    recipe.Ingredients.Add(
                        (
                            i.Name,
                            i.Quantity,
                            i.Unit.Name,
                            i.Unit.Label
                        ));
                }

                Console.WriteLine(
                    $"\t{recipe.RecipeName}\n" +
                    $"\t\t{recipe.Description}\n" +
                    $"\t\t{recipe.Instructions}" +
                    $"\t\t{recipe.Source}" +
                    $"\t\t{string.Join(',', recipe.Ingredients)}" +
                    $"\t\t{string.Join(',',  recipe.Tags)}"
                );
            }
        }
    }
}