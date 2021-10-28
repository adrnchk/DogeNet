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
    public class FriendRequestConfiguration : IEntityTypeConfiguration<FriendRequest>
    {
        public void Configure(EntityTypeBuilder<FriendRequest> builder)
        {
            builder.ToTable(nameof(FriendRequest)).HasKey(entity => entity.Id);

            builder.HasOne(d => d.Friend)
                .WithMany(p => p.FriendRequestFriends)
                .HasForeignKey(d => d.FriendId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.User)
                .WithMany(p => p.FriendRequestUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
