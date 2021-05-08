using Microsoft.EntityFrameworkCore;
using MyStaffWpf2.Model;

namespace MyStaffWpf2.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Staff> staffs { get; set; }

        public DbSet<Department> departments { get; set; }

        public DbSet<Position> positions { get; set; }

        public ApplicationContext()
        {
            // если БД нет, то создает
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=mystaff;Trusted_Connection=True;");
        }

    }
}
