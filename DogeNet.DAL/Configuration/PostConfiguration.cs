// <copyright file="PostConfiguration.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.DAL.Configuration
{
    using DogeNet.DAL.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable(nameof(Post)).HasKey(entity => entity.Id);

            builder.HasOne(d => d.Creator)
                .WithMany(p => p.Posts)
                .HasForeignKey(d => d.CreatorId);
        }
    }
}
