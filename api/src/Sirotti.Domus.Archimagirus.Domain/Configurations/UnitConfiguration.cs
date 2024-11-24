using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sirotti.Domus.Archimagirus.Domain;

public class UnitConfiguration : IEntityTypeConfiguration<Unit>
{
    public void Configure(EntityTypeBuilder<Unit> entity)
    {
        entity.HasIndex(u => u.Name).IsUnique();
        entity.HasIndex(u => u.Label).IsUnique();
    }
}