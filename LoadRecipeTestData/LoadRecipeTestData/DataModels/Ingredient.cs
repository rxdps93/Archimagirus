using System.ComponentModel.DataAnnotations.Schema;

namespace LoadRecipeTestData.DataModels;

public class Ingredient
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(TypeName = "int")]
    public int ID { get; set; }

    [Column(TypeName = "nvarchar(256)")]
    public required string Name { get; set; }

    public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
    public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
}