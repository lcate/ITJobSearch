using ITJobSearch.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITJobSearch.Infrastructure.Mappings
{
    public class UserTestMapping : IEntityTypeConfiguration<UserTest>
    {
        public void Configure(EntityTypeBuilder<UserTest> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Feedback)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(b => b.TestId)
                .IsRequired();


            builder.ToTable("UserTests");
        }
    }
}
