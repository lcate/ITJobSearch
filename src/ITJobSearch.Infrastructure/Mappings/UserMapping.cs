using ITJobSearch.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITJobSearch.Infrastructure.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Email)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Password)
                .IsRequired()
                .HasColumnType("varchar(100)");


            builder.Property(c => c.Type)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(b => b.CompanyId)
                .IsRequired();

            // 1 : N => User : JobApplication
            builder.HasMany(c => c.JobApplications)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId);

            // 1 : N => User : UserTest
            builder.HasMany(c => c.UserTests)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId);

            // 1 : N => User : Comment
            builder.HasMany(c => c.Comments)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId);

            builder.ToTable("Users");
        }
    }
}
