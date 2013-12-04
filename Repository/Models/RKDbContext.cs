using System.Data.Entity;
using Repository.Models.Mappings;

namespace Repository.Models
{
    public class RKDbContext : DbContext
    {
        static RKDbContext()
        {
            //Database.SetInitializer<RKDbContext>(null);
        }

        public RKDbContext()
            : base("PgSqlServices")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<UserDetails> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserDetailsMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}