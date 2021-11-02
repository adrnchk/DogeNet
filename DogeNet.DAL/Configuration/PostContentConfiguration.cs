// <copyright file="PostContentConfiguration.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.DAL.Configuration
{
    using DogeNet.DAL.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PostContentConfiguration : IEntityTypeConfiguration<PostContent>
    {
        public void Configure(EntityTypeBuilder<PostContent> builder)
        {
            builder.ToTable(nameof(PostContent)).HasKey(entity => entity.Id);

            builder.HasOne(d => d.Post)
                   .WithMany(p => p.PostContents)
                   .HasForeignKey(d => d.PostId);
        }
    }
}
