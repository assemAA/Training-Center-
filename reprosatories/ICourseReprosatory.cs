using ITI_Project.Models;

namespace ITI_Project.reprosatories
{
    public interface ICourseReprosatory
    {
         List<Course> getAll();

        void addCourse(Course course);

        void editCourse(Course course);

        public bool courseExists(int id);

        void delete(int id);

        public Course getDetails(int? id);

        public Course findCourse(int? id);
    }
}
