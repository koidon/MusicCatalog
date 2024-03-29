using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicCatalog.Models;

namespace MusicCatalog.Data.Configurations;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.Property(b => b.CreatedAt)
            .HasDefaultValueSql("NOW()");
        builder.Property(b => b.UpdatedAt)
            .HasDefaultValueSql("NOW()");
    } }