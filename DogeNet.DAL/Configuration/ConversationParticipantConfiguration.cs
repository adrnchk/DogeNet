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
    public class ConversationParticipantConfiguration : IEntityTypeConfiguration<ConversationParticipant>
    {
        public void Configure(EntityTypeBuilder<ConversationParticipant> builder)
        {
            builder.ToTable(nameof(City)).HasKey(entity => entity.Id);

            builder.HasOne(d => d.Conversation)
                .WithMany(p => p.ConversationParticipants)
                .HasForeignKey(d => d.ConversationId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.User)
                .WithMany(p => p.ConversationParticipants)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
