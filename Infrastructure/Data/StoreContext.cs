using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Advise> Advises { get; set; }
        public DbSet<CountryCity> CountryCities { get; set; }
        public DbSet<Question> Questions{get; set;}
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<StudyField> StudyFields { get; set; }
        public DbSet<VisaKind> VisaKinds { get; set; }
        public DbSet<VisitKind> VisitKinds { get; set; }

    }
}