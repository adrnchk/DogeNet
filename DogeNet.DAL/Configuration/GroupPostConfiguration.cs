// <copyright file="GroupPostConfiguration.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.DAL.Configuration
{
    using DogeNet.DAL.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class GroupPostConfiguration : IEntityTypeConfiguration<GroupPost>
    {
        public void Configure(EntityTypeBuilder<GroupPost> builder)
        {
            builder.ToTable(nameof(GroupPost)).HasKey(entity => entity.Id);

            builder.HasOne(d => d.Owner)
                   .WithMany(p => p.GroupPosts)
                   .HasForeignKey(d => d.OwnerId)
                   .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.Post)
                .WithMany(p => p.GroupPosts)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
