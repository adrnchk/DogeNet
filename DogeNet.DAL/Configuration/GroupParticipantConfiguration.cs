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
