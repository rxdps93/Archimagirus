using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Sirotti.Domus.Archimagirus.Domain.Contexts;

public class RecipeContext : DbContext
{
    private readonly string _dbSchema = "recipes";

    public virtual DbSet<Recipe> Recipes { get; set; }
    public virtual DbSet<Ingredient> Ingredients { get; set; }
    public virtual DbSet<Unit> Units { get; set; }
    public virtual DbSet<Tag> Tags { get; set; }
    public virtual DbSet<RecipeIngredient> RecipeIngredients { get; set; }
    public virtual DbSet<RecipeTag> RecipeTags { get; set; }

    public RecipeContext(DbContextOptions<RecipeContext> context) : base(context)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(_dbSchema);

        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new RecipeConfiguration());
        modelBuilder.ApplyConfiguration(new IngredientConfiguration());
        modelBuilder.ApplyConfiguration(new UnitConfiguration());
        modelBuilder.ApplyConfiguration(new TagConfiguration());
        modelBuilder.ApplyConfiguration(new RecipeIngredientConfiguration());
        modelBuilder.ApplyConfiguration(new RecipeTagConfiguration());
    }
}