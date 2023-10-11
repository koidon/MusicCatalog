using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicCatalog.Models;

namespace MusicCatalog.Data.Configurations;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.Property(b => b.Content)
            .HasMaxLength(Post.MaxContentLength);
        builder.Property(b => b.CreatedAt)
            .HasDefaultValueSql("curdate()");
        builder.Property(b => b.UpdatedAt)
            .HasDefaultValueSql("curdate()");
    }
}