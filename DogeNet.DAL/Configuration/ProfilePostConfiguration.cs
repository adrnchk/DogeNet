// <copyright file="ProfilePostConfiguration.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.DAL.Configuration
{
    using DogeNet.DAL.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ProfilePostConfiguration : IEntityTypeConfiguration<ProfilePost>
    {
        public void Configure(EntityTypeBuilder<ProfilePost> builder)
        {
            builder.ToTable(nameof(ProfilePost)).HasKey(entity => entity.Id);

            builder.HasOne(d => d.Owner)
                   .WithMany(p => p.ProfilePosts)
                   .HasForeignKey(d => d.OwnerId)
                   .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.Post)
                .WithMany(p => p.ProfilePosts)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
