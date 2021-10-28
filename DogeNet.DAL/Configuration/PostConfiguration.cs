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
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable(nameof(Post)).HasKey(entity => entity.Id);

            builder.HasOne(d => d.Creator)
                .WithMany(p => p.Posts)
                .HasForeignKey(d => d.CreatorId);
        }
    }
}
