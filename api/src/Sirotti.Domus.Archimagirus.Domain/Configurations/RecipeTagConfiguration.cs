using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sirotti.Domus.Archimagirus.Domain;

public class RecipeTagConfiguration : IEntityTypeConfiguration<RecipeTag>
{
    public void Configure(EntityTypeBuilder<RecipeTag> entity)
    {
        entity.ToTable("RecipeTags", "recipes");

        entity.Property(rt => rt.ID).UseIdentityColumn().IsRequired();

        entity.HasIndex(rt => new { rt.RecipeID, rt.TagID }).IsUnique();
    }
}