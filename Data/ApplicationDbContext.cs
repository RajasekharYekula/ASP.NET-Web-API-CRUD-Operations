using EmpAdminPortal.Modals.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmpAdminPortal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}
