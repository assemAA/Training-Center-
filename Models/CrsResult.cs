using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_Project.Models
{
    public class CrsResult
    {
        [Key]
        public int id { get; set; }

        public double degree { get; set; }

        [ForeignKey("Course")]
        public int crs_id { get; set; }

        [ForeignKey("Trainee")]
        public int trainee_id { get; set; }

        
        public virtual Trainee? Trainee { get; set; }

        public virtual Course? Course { get; set; }
    }
}
