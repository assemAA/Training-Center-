using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_Project.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required(AllowEmptyStrings =false , ErrorMessage = "course name is required")]
        [MaxLength(20 , ErrorMessage = "course name cannot exceed 20 letter")]
        [MinLength(2 , ErrorMessage = "course name at least two letters")]
        [Unique]
        public string name { get; set; }
        [Required]
        [Range(50 , 100)]
       
        public double degree { get; set; }
        [Required]
        [Remote("minDegree" , "Courses" , AdditionalFields = "degree" , ErrorMessage ="min degree must less than degree")]
        public double min_degree { get; set; }

        [ForeignKey("Departement")]
        [DisplayName("Departement Name")]
        public int dept_id { get; set; }
        public virtual Departement? Departement { get; set; }

    }
}
