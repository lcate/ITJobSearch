using ITJobSearch.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITJobSearch.Infrastructure.Mappings
{
    public class JobApplicationMapping : IEntityTypeConfiguration<JobApplication>
    {
        public void Configure(EntityTypeBuilder<JobApplication> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Status)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(b => b.UserId)
                .IsRequired();

            builder.Property(b => b.JobOfferId)
                .IsRequired();

            // 1 : N => JobApplication : Comment
            builder.HasMany(c => c.Comments)
                .WithOne(b => b.JobApplication)
                .HasForeignKey(b => b.JobApplicationId);

            builder.ToTable("JobApplications");
        }
    }
}
