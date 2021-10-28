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
