// <copyright file="GroupParticipantConfiguration.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.DAL.Configuration
{
    using DogeNet.DAL.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class GroupParticipantConfiguration : IEntityTypeConfiguration<GroupParticipant>
    {
        public void Configure(EntityTypeBuilder<GroupParticipant> builder)
        {
            builder.ToTable(nameof(GroupParticipant)).HasKey(entity => entity.Id);

            builder.HasOne(d => d.Group)
                    .WithMany(p => p.GroupParticipants)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.User)
                .WithMany(p => p.GroupParticipants)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
