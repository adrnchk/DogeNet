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
    public class BlackListConfiguration : IEntityTypeConfiguration<BlackList>
    {
        public void Configure(EntityTypeBuilder<BlackList> builder)
        {
            builder.ToTable(nameof(BlackList)).HasKey(entity => entity.Id);

            builder.HasOne(d => d.Friend)
                .WithMany(p => p.BlackListFriends)
                .HasForeignKey(d => d.FriendId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.User)
                .WithMany(p => p.BlackListUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
