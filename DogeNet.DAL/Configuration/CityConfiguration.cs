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
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable(nameof(City)).HasKey(entity => entity.Id);

            builder.HasOne(d => d.Country)
                .WithMany(p => p.Cities)
                .HasForeignKey(d => d.CountryId);
        }
    }
}
