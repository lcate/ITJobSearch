using ITJobSearch.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITJobSearch.Infrastructure.Mappings
{
    public class JobOfferMapping : IEntityTypeConfiguration<JobOffer>
    {
        public void Configure(EntityTypeBuilder<JobOffer> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Position)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Description)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Salary)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.WorkHours)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(b => b.CompanyId)
                .IsRequired();

            // 1 : N => JobOffer : JobApplication
            builder.HasMany(c => c.JobApplications)
                    .WithOne(b => b.JobOffer)
                    .HasForeignKey(b => b.JobOfferId);

            builder.ToTable("JobOffers");
        }
    }
}
