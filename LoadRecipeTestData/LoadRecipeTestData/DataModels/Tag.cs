using System.ComponentModel.DataAnnotations.Schema;

namespace LoadRecipeTestData.DataModels;

public class Tag
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(TypeName = "int")]
    public int ID { get; set; }

    [Column(TypeName = "nvarchar(128)")]
    public required string Name { get; set; }

    public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
    public ICollection<RecipeTag> RecipeTags { get; set; } = new List<RecipeTag>();
}