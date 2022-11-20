
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(m => m.Name).IsRequired().HasMaxLength(50);
            builder.Property(m => m.SoftDeleted).HasDefaultValue(false);
            builder.Property(m => m.CreatedDate).HasDefaultValue(DateTime.UtcNow);

            builder.HasQueryFilter(m => !m.SoftDeleted);
        }
    }
}
