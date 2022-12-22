using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace Lab.Model
{
    public class DataBaseContext : DbContext
    {
        //public DataBaseContext()
        //{
        //    Database.EnsureCreated();
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder _context)
        {
            _context.UseSqlServer("Server=ASUS;DataBase=laba2;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
