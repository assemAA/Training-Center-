using ITI_Project.Models;

namespace ITI_Project.reprosatories
{
    public class DepartementReprosatory : IDepartementReprosatory
    {
        CourseSystem context;
        public Guid id;
        public DepartementReprosatory (CourseSystem _context)
        {
            context = _context;
            id = new Guid();
        }

        public List<Departement> getAll()
        {
            return context.Departements.ToList();
        }


    }
}
