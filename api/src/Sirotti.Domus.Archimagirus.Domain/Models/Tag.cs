using System.ComponentModel.DataAnnotations.Schema;

namespace Sirotti.Domus.Archimagirus.Domain;

public class Tag
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(TypeName = "int")]
    public int ID { get; set; }

    [Column(TypeName = "nvarchar")]
    public required string Name { get; set; }

    public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
    public ICollection<RecipeTag> RecipeTags { get; set; } = new List<RecipeTag>();
}