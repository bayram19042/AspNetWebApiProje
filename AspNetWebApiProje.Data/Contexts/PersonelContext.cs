using AspNetWebApiProje.Core.Entities;
using AspNetWebApiProje.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetWebApiProje.Data.Contexts
{
    public class PersonelContext:DbContext
    {
        public PersonelContext(DbContextOptions<PersonelContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonelConfiguration());
            modelBuilder.ApplyConfiguration(new AdresConfiguration());
        }
        public DbSet<Personel> Personel { get; set; }
        public DbSet<Adres> Adres { get; set; }
    }
}
