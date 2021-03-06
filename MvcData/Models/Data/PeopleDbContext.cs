using Microsoft.EntityFrameworkCore;
using MvcData.Models.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace MvcData.Models.Data
{
    public class PeopleDbContext : IdentityDbContext<AppUser>
    {

        public PeopleDbContext(DbContextOptions<PeopleDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PersonLanguage>().HasKey(pl =>
           new
           {
               pl.PersonId,
               pl.LanguageId
           });

            modelBuilder.Entity<PersonLanguage>()
                .HasOne<Person>(pl => pl.Person)
                .WithMany(p => p.PersonLanguages)
                .HasForeignKey(pl => pl.PersonId);

            modelBuilder.Entity<PersonLanguage>()
               .HasOne<Language>(pl => pl.Language)
               .WithMany(l => l.PersonLanguages)
               .HasForeignKey(pl => pl.LanguageId);
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<PersonLanguage> PersonLanguages { get; set; }


    }

}

