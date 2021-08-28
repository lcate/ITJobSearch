using ITJobSearch.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITJobSearch.Infrastructure.Mappings
{
    public class TestMapping : IEntityTypeConfiguration<Test>
    {
        public void Configure(EntityTypeBuilder<Test> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.TestText)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.Property(b => b.CompanyId)
                .IsRequired();

            // 1 : N => Test : UserTest
            builder.HasMany(c => c.UserTests)
                .WithOne(b => b.Test)
                .HasForeignKey(b => b.TestId);

            builder.ToTable("Tests");
        }
    }
}
