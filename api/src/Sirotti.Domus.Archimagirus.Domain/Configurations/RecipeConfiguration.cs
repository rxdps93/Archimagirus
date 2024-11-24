using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sirotti.Domus.Archimagirus.Domain;

public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> entity)
    {
        entity.HasMany(r => r.RecipeIngredients)
            .WithOne(ri => ri.Recipe)
            .HasForeignKey(ri => ri.RecipeID);

        entity.HasMany(r => r.Ingredients)
            .WithMany(i => i.Recipes)
            .UsingEntity<RecipeIngredient>();

        entity.HasMany(r => r.Units)
            .WithMany(u => u.Recipes)
            .UsingEntity<RecipeIngredient>();

        entity.HasMany(r => r.RecipeTags)
            .WithOne(rt => rt.Recipe)
            .HasForeignKey(rt => rt.RecipeID);

        entity.HasMany(r => r.Tags)
            .WithMany(t => t.Recipes)
            .UsingEntity<RecipeTag>();
    }
}