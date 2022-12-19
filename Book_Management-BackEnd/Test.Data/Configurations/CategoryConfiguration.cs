using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Data.Entities;

namespace Test.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> modelBuilder)
        {
            modelBuilder.ToTable("Category")
                         .HasKey(Cat => Cat.CategoryId);

            modelBuilder.Property(Cat => Cat.CategoryId)
                        .HasColumnName("CategoryId")
                        .HasColumnType("int")
                        .UseIdentityColumn(1)
                        .IsRequired();

            modelBuilder.Property(Cat => Cat.CategoryName)
                        .HasColumnName("CategoryName")
                        .HasColumnType("nvarchar")
                        .HasMaxLength(500)
                        .IsRequired();

            modelBuilder.Property(p => p.Description)
                        .HasColumnName("Description")
                        .HasColumnType("nvarchar")
                        .HasMaxLength(500)
                        .IsRequired();
        }
    }
}
