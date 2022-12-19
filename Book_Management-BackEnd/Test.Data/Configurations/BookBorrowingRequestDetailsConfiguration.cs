using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Data.Entities;

namespace Test.Data.Configurations
{
    public class BookBorrowingRequestDetailsConfiguration : IEntityTypeConfiguration<BookBorrowingRequestDetails>
    {
        public void Configure(EntityTypeBuilder<BookBorrowingRequestDetails> builder)
        {
            builder.ToTable("BookBorrowingRequestDetails");

            builder.HasKey(d => d.Id);

            builder.HasOne(b => b.BookBorrowingRequest)
                   .WithMany(r => r.Details)
                   .HasForeignKey(b => b.BookBorrowingRequestId)
                    .IsRequired();

            builder.HasOne(b => b.Book)
                   .WithMany(r => r.Details)
                   .HasForeignKey(b => b.BookId)
                   .IsRequired();
        }
    }
}
