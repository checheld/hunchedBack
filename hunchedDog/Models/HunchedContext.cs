using Microsoft.EntityFrameworkCore;

namespace hunchedDogBackend.Models
{
    public class HunchedContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public object Profiles { get; internal set; }

        public HunchedContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Console.WriteLine("Connection is opened");
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=huncheddogdb;Trusted_Connection=True;");
        }
    }
}
