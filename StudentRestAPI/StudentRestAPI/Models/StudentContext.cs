using Microsoft.EntityFrameworkCore;

namespace StudentRestAPI.Models  //Created for memory usage, decided not to use it
{
    public class StudentContext:DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options): base(options)
        { 

        }
        public DbSet<Student> Students { get; set; } = null;
    }
}
