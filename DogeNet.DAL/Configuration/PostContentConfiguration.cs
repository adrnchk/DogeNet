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
    public class PostContentConfiguration : IEntityTypeConfiguration<PostContent>
    {
        public void Configure(EntityTypeBuilder<PostContent> builder)
        {
            builder.ToTable(nameof(PostContent)).HasKey(entity => entity.Id);

            builder.HasOne(d => d.Post)
                   .WithMany(p => p.PostContents)
                   .HasForeignKey(d => d.PostId);
        }
    }
}
