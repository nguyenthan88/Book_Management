using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using Test.Data.Entities;

namespace Test.Data.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
                 builder.ToTable("Book")
                        .HasKey(p => p.BookId);

                 builder.Property(p => p.BookId)
                        .HasColumnName("BookID")
                        .HasColumnType("int")
                        .UseIdentityColumn(1)
                        .IsRequired();

                 builder.Property(p => p.BookName)
                        .HasColumnName("BookName")
                        .HasColumnType("nvarchar")
                        .HasMaxLength(500)
                        .IsRequired();

                 builder.Property(p => p.Description)
                        .HasColumnName("Description")
                        .HasColumnType("nvarchar")
                        .HasMaxLength(500);

                 builder.Property(p => p.PublishingYear)
                        .HasColumnName("PublishingYear")
                        .HasColumnType("Date")
                        .HasMaxLength(500)
                        .IsRequired();

                 builder.Property(p => p.Price)
                        .HasColumnName("Price")
                        .HasColumnType("int")
                        .IsRequired();
        }
    }
}
