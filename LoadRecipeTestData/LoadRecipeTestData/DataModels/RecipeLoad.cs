namespace LoadRecipeTestData.DataModels;

public class RecipeLoad
{
    public required string RecipeName { get; set; }
    public string? Description { get; set; }
    public required string Instructions {get; set; }
    public string? Source { get; set; }

    /* IngredientName, Quantity, UnitName, UnitLabel */
    public required List<(string, decimal, string, string)> Ingredients { get; set; }

    public required List<string> Tags { get; set; }
}