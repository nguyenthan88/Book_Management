using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using Test.Data.Entities;

namespace Test.Data.Configurations
{
    public class BookBorrowingRequestConfiguration : IEntityTypeConfiguration<BookBorrowingRequest>
    {
        public void Configure(EntityTypeBuilder<BookBorrowingRequest> modelBuilder)
        {
            modelBuilder.ToTable("BookBorrowingRequest")
                        .HasKey(u => u.Id);
            
            modelBuilder.HasOne(u => u.RequestedBy)
                        .WithMany(u => u.BookBorrowingRequests)
                        .HasForeignKey(u => u.RequestByUserId)
                        .IsRequired();

            modelBuilder.HasOne(u => u.ProcessedBy)
                        .WithMany(u => u.ProcessedRequests)
                        .HasForeignKey(u => u.ProcessedByUserId)
                        .IsRequired(false);         
        }
    }
}
