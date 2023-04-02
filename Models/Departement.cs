using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_Project.Models
{
    public class Departement
    {
        [Key]
        public int id { get; set; }

        public string name { get; set; }

        //[ForeignKey("Manager")]
        public string  manager { get; set; }

        public virtual List<Instractor>? Instractors { get; set; }

       // public virtual Instractor? Manager { get; set; }
        public virtual List<Course>? Courses { get; set; }

        public virtual List<Trainee>? Trainees { get; set; }

    }
}
