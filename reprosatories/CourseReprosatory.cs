using ITI_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace ITI_Project.reprosatories
{
    public class CourseReprosatory : ICourseReprosatory
    {
        CourseSystem context;
        public Guid id;
        public CourseReprosatory (CourseSystem context)
        {
            this.context = context;
            id= Guid.NewGuid ();
        }

        public List<Course> getAll()
        {
            return context.Courses.ToList();
        }

        public void addCourse (Course course)
        {
            context.Add(course);
            context.SaveChanges();
        }

        public void editCourse(Course course)
        {
            context.Update(course);
            context.SaveChanges();
        }

        public bool courseExists (int id )
        {
            return (context.Courses?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public void delete (int id)
        {
            var course = context.Courses.Find(id);
            if (course != null)
            {
                context.Courses.Remove(course);
            }

            context.SaveChanges();
        }

        public Course getDetails (int? id)
        {

            var course = context.Courses
                .Include(c => c.Departement)
                .FirstOrDefault(m => m.Id == id);

            return course;
        }

        public Course findCourse (int? id)
        {
           return context.Courses.Find(id);
        }
    }
}
