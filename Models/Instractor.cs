using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_Project.Models
{
    public class Instractor
    {
        [Key]
        public int id { get; set; } 

        public string name { get; set; }    

        public string imag { get; set; }

        public double salary { get; set; }

        public string address { get; set; }

        [ForeignKey("Departement")]
        public int? dept_id { get; set; }

        public virtual List<Course>? Courses { get; set; }

        public virtual Departement? Departement { get; set; }

    }
}
