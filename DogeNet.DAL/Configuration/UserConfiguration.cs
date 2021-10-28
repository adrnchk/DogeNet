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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User)).HasKey(entity => entity.Id);

            builder.Property(e => e.FirstName).IsRequired();

            builder.HasOne(d => d.City)
                .WithMany(p => p.Users)
                .HasForeignKey(d => d.CityId);

            builder.HasOne(d => d.Status)
                .WithMany(p => p.Users)
                .HasForeignKey(d => d.StatusId);
        }
    }
}
