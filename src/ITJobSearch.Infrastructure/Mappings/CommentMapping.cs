using ITJobSearch.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITJobSearch.Infrastructure.Mappings
{
    public class CommentMapping : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Message)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(b => b.UserId)
                .IsRequired();

            builder.Property(b => b.JobApplicationId)
                .IsRequired();

            builder.ToTable("Comments");
        }
    }
}
