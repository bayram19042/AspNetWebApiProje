using AspNetWebApiProje.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetWebApiProje.Data.Configuration
{
    public class AdresConfiguration : IEntityTypeConfiguration<Adres>
    {
        public void Configure(EntityTypeBuilder<Adres> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.AdresAciklama).IsRequired().HasMaxLength(200);
        }
    }
}
