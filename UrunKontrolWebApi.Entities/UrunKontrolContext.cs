using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrunKontrolWebApi.Entities
{
    public class UrunKontrolContext:DbContext
    {
        public DbSet<TBLKULLANICI_MKA> TBLKULLANICI_MKA { get; set; }
        public DbSet<TBLSEPET_MKA> TBLSEPET_MKA { get; set; }
        public DbSet<TBLSEPETUST_MKA> TBLSEPETUST_MKA { get; set; }

        //views
        public DbSet<STOKBAKIYEOTR> STOKBAKIYEOTR { get; set; }
        public DbSet<STOKBAKIYE_MKA> STOKBAKIYE_MKA { get; set; }
        public DbSet<SEPET_MKA> SEPET_MKA { get; set; }
        public DbSet<SEPETUST_MKA> SEPETUST_MKA { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TBLKULLANICI_MKA>().ToTable("TBLKULLANICI_MKA");
            modelBuilder.Entity<TBLSEPET_MKA>().ToTable("TBLSEPET_MKA");
            modelBuilder.Entity<TBLSEPETUST_MKA>().ToTable("TBLSEPETUST_MKA");

            //views
            modelBuilder.Entity<STOKBAKIYEOTR>().ToTable("STOKBAKIYEOTR");
            modelBuilder.Entity<STOKBAKIYE_MKA>().ToTable("STOKBAKIYE_MKA");
            modelBuilder.Entity<SEPET_MKA>().ToTable("SEPET_MKA");
            modelBuilder.Entity<SEPETUST_MKA>().ToTable("SEPETUST_MKA");
        }
    }
}
