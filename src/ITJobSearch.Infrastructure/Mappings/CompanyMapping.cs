using ITJobSearch.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITJobSearch.Infrastructure.Mappings
{
    public class CompanyMapping : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(c => c.WebURL)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.Property(c => c.Logo)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.Property(c => c.UserId)
                .IsRequired()
                .HasColumnType("varchar(450)");

            builder.Property(c => c.Linkedin)
                .IsRequired()
                .HasColumnType("varchar(300)");

            builder.Property(c => c.AboutUs)
                .IsRequired()
                .HasColumnType("varchar(500)");

            // 1 : N => Company : Users
            //builder.HasMany(c => c.Users)
            //       .WithOne(b => b.Company)
            //       .HasForeignKey(b => b.CompanyId);

            // 1 : N => Company : JobOffer
            //builder.HasMany(c => c.JobOffers)
            //       .WithOne(b => b.Company)
            //       .HasForeignKey(b => b.CompanyId);

            // 1 : N => Company : Test
            builder.HasMany(c => c.Tests)
                   .WithOne(b => b.Company)
                   .HasForeignKey(b => b.CompanyId);

            builder.ToTable("Companies");
        }
    }
}
