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
    class GroupPostConfiguration : IEntityTypeConfiguration<GroupPost>
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
