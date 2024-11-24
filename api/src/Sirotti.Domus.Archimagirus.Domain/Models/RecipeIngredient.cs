namespace Sirotti.Domus.Archimagirus.Domain;

public class RecipeIngredient
{
    public int ID { get; set; }

    public required int RecipeID { get; set; }

    public required int IngredientID { get; set; }

    public required int UnitID { get; set; }

    public required decimal Quantity { get; set; }

    public Recipe? Recipe { get; set; } = null;
    public Ingredient? Ingredient { get; set; } = null;
    public Unit? Unit { get; set; } = null;
}