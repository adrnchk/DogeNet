// <copyright file="ConversationConfiguration.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.DAL.Configuration
{
    using DogeNet.DAL.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ConversationConfiguration : IEntityTypeConfiguration<Conversation>
    {
        public void Configure(EntityTypeBuilder<Conversation> builder)
        {
            builder.ToTable(nameof(Conversation)).HasKey(entity => entity.Id);

            builder.Property(e => e.Title).IsRequired();

            builder.HasOne(d => d.Creator)
                .WithMany(p => p.Conversations)
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.Status)
                .WithMany(p => p.Conversations)
                .HasForeignKey(d => d.StatusId);
        }
    }
}
