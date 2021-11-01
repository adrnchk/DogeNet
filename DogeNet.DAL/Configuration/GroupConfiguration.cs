// <copyright file="GroupConfiguration.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.DAL.Configuration
{
    using DogeNet.DAL.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable(nameof(Group)).HasKey(entity => entity.Id);

            builder.Property(e => e.Name).IsRequired();

            builder.HasOne(d => d.Creator)
                .WithMany(p => p.Groups)
                .HasForeignKey(d => d.CreatorId);

            builder.HasOne(d => d.Status)
                .WithMany(p => p.Groups)
                .HasForeignKey(d => d.StatusId);
        }
    }
}
