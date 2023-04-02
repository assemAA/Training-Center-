using System.ComponentModel.DataAnnotations;

namespace ITI_Project.Models
{
    public class UniqueAttribute : ValidationAttribute
    {
        CourseSystem db;
        List<Course> courses;

        public UniqueAttribute()
        {
            db= new CourseSystem();
            this.courses = db.Courses.ToList();
        }

        protected override ValidationResult? IsValid(object? value , ValidationContext validationContext)
        {
            string name = value as string;
            Course course = courses.Where( c=> c.name == name).FirstOrDefault();
            if (course == null) {
                return ValidationResult.Success;
            }
            return new ValidationResult("Name must be unique ");
        }




    }
}
