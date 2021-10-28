using DogeNet.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeNet.DAL.Configuration
{
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
