using Microsoft.EntityFrameworkCore;

namespace ITI_Project.Models
{
    public class CourseSystem : DbContext
    {
        public DbSet<Course> Courses { get;set; }
        public DbSet<Instractor> Instractors { get;set; }

        public DbSet<Trainee> Trainees { get;set; }

        public DbSet<Departement> Departements { get;set; }

        public DbSet<CrsResult> CrsResults { get;set; }

        public CourseSystem() : base()
        {

        }

        public CourseSystem(DbContextOptions options ) :base(options)
        {

        } 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-Q8GVO7K;Initial Catalog=CourseSystem;Integrated Security=True;Encrypt=False");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
