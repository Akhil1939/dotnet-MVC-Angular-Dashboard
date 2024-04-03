using System.Data.Entity;

namespace MVC_Angular_demo.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name=DefaultConnection")
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Define relationships
            modelBuilder.Entity<Users>()
                .HasRequired(u => u.Role)
                .WithMany()
                .HasForeignKey(u => u.RoleId)
                .WillCascadeOnDelete(false); // Optional: Specify cascade delete behavior if needed
        }
    }
}