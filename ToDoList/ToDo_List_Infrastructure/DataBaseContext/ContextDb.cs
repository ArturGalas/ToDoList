using Microsoft.EntityFrameworkCore;
using ToDo_List_Core.Models;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace ToDo_List_Infrastructure.DataBaseContext
{
    public class ContextDb:DbContext
    {
        public ContextDb(DbContextOptions<ContextDb> options)
        : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(con => con.MigrationsAssembly("Artur_Galas_ToDo_List"));
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tasks>()
                .HasKey(ts => ts.Id);
            modelBuilder.Entity<User>()
                .HasKey(us => us.Id);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Tasks> tasks { get; set; }
    }
}
