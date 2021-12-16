using Microsoft.EntityFrameworkCore;
using MvcData.Models.ViewModels;

namespace MvcData.Models.Data
{
    public class PeopleDbContext : DbContext
    {

        public PeopleDbContext(DbContextOptions<PeopleDbContext> options) : base(options)
        { }

        public DbSet<Person> People{ get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Language> Languages { get; set; }


    }

}

 