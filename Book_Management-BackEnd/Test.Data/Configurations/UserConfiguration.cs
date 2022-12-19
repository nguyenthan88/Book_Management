using Common.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using Test.Data.Entities;

namespace Test.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> modelBuilder)
        {
            modelBuilder.ToTable("User")
                        .HasKey(u => u.UserId);

            modelBuilder.Property(u => u.UserId)
                        .HasColumnName("UserId")
                        .HasColumnType("int")
                        .UseIdentityColumn(1)
                        .IsRequired();

            modelBuilder.Property(u => u.UserName)
                        .HasColumnName("UserName")
                        .HasColumnType("nvarchar")
                        .HasMaxLength(500)
                        .IsRequired();

            modelBuilder.Property(u => u.Password)
                        .HasColumnName("Password")
                        .HasColumnType("nvarchar")
                        .HasMaxLength(500)
                        .IsRequired();

            modelBuilder.Property(u => u.FirstName)
                        .HasColumnName("FirstName")
                        .HasColumnType("nvarchar")
                        .HasMaxLength(500)
                        .IsRequired();

            modelBuilder.Property(u => u.LastName)
                        .HasColumnName("LastName")
                        .HasColumnType("nvarchar")
                        .HasMaxLength(500)
                        .IsRequired();
        }
    }
}
