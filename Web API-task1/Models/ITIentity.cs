using Microsoft.EntityFrameworkCore;

namespace Web_API_task1.Models
{
    public class ITIentity: DbContext
    {
        public ITIentity()
        {
        }
        public ITIentity(DbContextOptions<ITIentity> options): base(options)
        {   
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=ITIentity;Trusted_Connection=True;Encrypt=False");
        }
       
    }
}
