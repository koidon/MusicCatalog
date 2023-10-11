using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicCatalog.Models;

namespace MusicCatalog.Data.Configurations;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.Property(b => b.Content)
            .HasMaxLength(Review.MaxContentLength);
        builder.Property(b => b.CreatedAt)
            .HasDefaultValueSql("curdate()");
        builder.Property(b => b.UpdatedAt)
            .HasDefaultValueSql("curdate()");
    } }