using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sirotti.Domus.Archimagirus.Domain;

public class RecipeIngredientConfiguration : IEntityTypeConfiguration<RecipeIngredient>
{
    public void Configure(EntityTypeBuilder<RecipeIngredient> entity)
    {
        entity.ToTable("RecipeIngredients", "recipes");

        entity.Property(ri => ri.ID).UseIdentityColumn().IsRequired();

        entity.HasIndex(ri => new { ri.RecipeID, ri.IngredientID}).IsUnique();
    }
}