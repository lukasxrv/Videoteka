using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.ComponentModel.DataAnnotations.Schema;
using Videoteka.DataModel;

namespace Videoteka
{
    public class VideotekaDbContext : DbContext
    {
        public VideotekaDbContext(string connString) : base(connString)
        {
        }

        public DbSet<Film> Film { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Film>().HasKey(x => x.IDFilm);
            modelBuilder.Entity<Film>().Property(x => x.IDFilm).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Film>().Property(x => x.Nazev).HasMaxLength(255);
            modelBuilder.Entity<Film>().Property(x => x.Zanr).HasMaxLength(255);
        }
    }
}
