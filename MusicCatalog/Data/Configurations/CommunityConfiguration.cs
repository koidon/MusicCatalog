using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicCatalog.Models;

namespace MusicCatalog.Data.Configurations;
public class CommunityConfiguration : IEntityTypeConfiguration<Community>
{
        public void Configure(EntityTypeBuilder<Community> builder)
        {
            builder.Property(b => b.Name)
                .HasMaxLength(Community.MaxContentLength);
            builder.Property(b => b.CreatedAt)
                .HasDefaultValueSql("curdate()");
            builder.Property(b => b.UpdatedAt)
                .HasDefaultValueSql("curdate()");
    }
}
