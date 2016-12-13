using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace AplikacjaRanczo.Models
{
    public class RanczoContext : DbContext
    {
        public RanczoContext() : base("DBRanczo")
        {
        }

        public DbSet<Bydlo> Bydlo { get; set; }
        public DbSet<KodPocztowy> KodPocztowy { get; set; }
        public DbSet<Kontrahent> Kontrahent { get; set; }
        public DbSet<Kraj> Kraj { get; set; }
        public DbSet<KsiegaSprzedazy> KsiegaSprzedazy { get; set; }
        public DbSet<Marka> Marka { get; set; }
        public DbSet<Miejscowosc> Miejscowosc { get; set; }
        public DbSet<Plec> Plec { get; set; }
        public DbSet<Rasa> Rasa { get; set; }
        public DbSet<Samochod> Samochod { get; set; }
        public DbSet<Wojewodztwo> Wojewodztwo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            
        }
    }
}