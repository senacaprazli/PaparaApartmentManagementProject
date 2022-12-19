using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DataLayer.Models;

namespace DataLayer
{
   public class UserContext : DbContext
    {
        //  private readonly IConfiguration configuration;
        protected IConfiguration Configuration { get; }

        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }

       public UserContext() { }

        //db connection string 

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
           // base.OnConfiguring(options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            options.UseSqlServer("Server=.;Database=ApartmentManagementAPI; integrated security = True;");
        }

        public DbSet<Blocks> Blocks { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<Occupants> Occupants { get; set; }
        public DbSet<Payments> Payments { get; set; }

        //The OnModelCreating method is a virtual method that is triggered when
        //the database is created for the first time. With the OnModelCreating
        //method, we can set table names as follows by intervening before tables are created.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blocks>().ToTable("Blocks");
            modelBuilder.Entity<Messages>().ToTable("Messages");
            modelBuilder.Entity<Occupants>().ToTable("Occupants");
            modelBuilder.Entity<Payments>().ToTable("Payments");

        }





    }
}
