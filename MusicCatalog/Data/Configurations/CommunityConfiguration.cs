using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicCatalog.Models;

namespace MusicCatalog.Data.Configurations;
public class CommunityConfiguration : IEntityTypeConfiguration<Community>
{
        public void Configure(EntityTypeBuilder<Community> builder)
        {
            builder.Property(b => b.CreatedAt)
                .HasDefaultValueSql("NOW()");
            builder.Property(b => b.UpdatedAt)
                .HasDefaultValueSql("NOW()");
    }
}
