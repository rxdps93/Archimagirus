namespace LoadRecipeTestData.DataModels;

public class RecipeTag
{
    public int ID { get; set; }

    public required int RecipeID { get; set; }

    public required int TagID { get; set; }

    public Recipe? Recipe { get; set; } = null;

    public Tag? Tag { get; set; } = null;
}