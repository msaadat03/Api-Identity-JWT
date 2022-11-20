using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(m => m.Name).IsRequired().HasMaxLength(50);
            builder.Property(m => m.Author).IsRequired().HasMaxLength(50);
            builder.Property(m => m.Count).IsRequired();
            builder.Property(m => m.Price).IsRequired().HasPrecision(12, 10);
            builder.Property(m => m.SoftDeleted).HasDefaultValue(false);
            builder.Property(m => m.CreatedDate).HasDefaultValue(DateTime.UtcNow);

            builder.HasQueryFilter(m => !m.SoftDeleted);
        }
    }
}
