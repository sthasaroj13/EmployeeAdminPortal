using EmployeeAdminPortal.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortal.Data
{
    public class ApplicationDbContext :DbContext
    {
        //base is use to pass the DbcontextOptions Object tp the base class or Parent class DbContext
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options) 
        {
            
        }
        //add properties to store in Db
        public DbSet<Employee> Employees { get; set; }
    }
}
/*The main use of the code you provided is to set up the Entity Framework Core (EF Core) 
 * infrastructure for managing a database in an application. Specifically, this code creates a custom
 * database context, ApplicationDbContext, which is used to interact with a database.*/