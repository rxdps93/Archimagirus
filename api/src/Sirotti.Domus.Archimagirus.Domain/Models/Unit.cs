using System.ComponentModel.DataAnnotations.Schema;

namespace Sirotti.Domus.Archimagirus.Domain;

public class Unit
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(TypeName = "int")]
    public int ID { get; set; }

    [Column(TypeName = "nvarchar")]
    public required string Name { get; set; }

    [Column(TypeName = "nvarchar")]
    public required string Label { get; set; }

    public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
    public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
}