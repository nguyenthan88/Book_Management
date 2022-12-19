using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Data.Entities;

namespace Test.Data.Configurations
{
    public class BookInCategoryConfiguration : IEntityTypeConfiguration<BookInCategory>
    {
        public void Configure(EntityTypeBuilder<BookInCategory> builder)
        {
            builder.HasKey(t => new { t.BookId, t.CategoryId });

            builder.ToTable("BookInCategories");

            builder.HasOne(t => t.Book)
                   .WithMany(bc=>bc.BookInCategories)
                   .HasForeignKey(bc=>bc.BookId);

            builder.HasOne(t => t.Category)
                   .WithMany(bc => bc.BookInCategories)
                   .HasForeignKey(bc => bc.CategoryId);
        }
    }
}
