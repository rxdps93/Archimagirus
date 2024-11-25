using System.ComponentModel.DataAnnotations.Schema;

namespace Sirotti.Domus.Archimagirus.Domain;

public class Recipe
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(TypeName = "int")]
    public int ID { get; set; }

    [Column(TypeName = "nvarchar(256)")]
    public required string Name { get; set; }

    [Column(TypeName = "nvarchar(max)")]
    public string? Description { get; set; }

    [Column(TypeName = "nvarchar(max)")]
    public required string Instructions { get; set; }

    [Column(TypeName = "nvarchar(max)")]
    public string? Source { get; set; }

    public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    public ICollection<Unit> Units { get; set; } = new List<Unit>();
    public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();

    public ICollection<Tag> Tags { get; set; } = new List<Tag>();
    public ICollection<RecipeTag> RecipeTags { get; set; } = new List<RecipeTag>();
}