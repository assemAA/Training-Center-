using ITI_Project.Models;
using ITI_Project.viewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITI_Project.Controllers
{
    public class StudentController : Controller
    {
        CourseSystem db = new CourseSystem();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult getStudentDegree(int std_id , int crs_id)
        {
            var crs_stdRecord = db.CrsResults.Include("Trainee").Include("Course").Where(r => r.crs_id == crs_id && r.trainee_id == std_id)
                                .Select( s => new { trainee = s.Trainee.name , course = s.Course.name , mindegree = s.Course.min_degree ,
                                studentDegree = s.degree}).ToList().FirstOrDefault();


            StudentGradeViewModel studentGradeViewModel = new StudentGradeViewModel();

            studentGradeViewModel.trainneeName = crs_stdRecord.trainee;
            studentGradeViewModel.coureName = crs_stdRecord.course;
            studentGradeViewModel.studentDegree = crs_stdRecord.studentDegree;
            double minCourseGrade = crs_stdRecord.mindegree;

            if (studentGradeViewModel.studentDegree < minCourseGrade)
            {
                studentGradeViewModel.color = "red";
            }else
            {
                studentGradeViewModel.color = "green";
            }



            return View("studentDegree" , studentGradeViewModel);
        }
    }
}
