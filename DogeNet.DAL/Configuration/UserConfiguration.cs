// <copyright file="UserConfiguration.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.DAL.Configuration
{
    using DogeNet.DAL.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User)).HasKey(entity => entity.Id);

            builder.HasOne(d => d.City)
                .WithMany(p => p.Users)
                .HasForeignKey(d => d.CityId);

            builder.HasOne(d => d.Status)
                .WithMany(p => p.Users)
                .HasForeignKey(d => d.StatusId);
        }
    }
}
