using ITI_Project.Models;
using ITI_Project.viewModels;
using Microsoft.AspNetCore.Mvc;
namespace ITI_Project.Controllers
{
    public class InstractorController : Controller
    {
        public CourseSystem db = new CourseSystem(); 
        public IActionResult Index()
        {
            List<Instractor> instractors = db.Instractors.ToList();

            return View(instractors);
        }


        public IActionResult NewIns ()
        {
            List<Departement> departements = db.Departements.ToList();
            ViewBag.departements =  departements;
            
            return View("addIns");
        }

        [HttpPost]
        public IActionResult NewIns (Instractor instractor )
        {

            if (instractor.name != null)
            {
                db.Instractors.Add(instractor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            List<Departement> departements = db.Departements.ToList();
            ViewBag.departements = departements;
            ViewBag.Courses = db.Courses.ToList();
            return View("addIns", instractor);
        }

        public IActionResult details (int id )
        {
            List<Instractor> instractors= db.Instractors.ToList();
            Instractor instractor = instractors.Where( i => i.id == id).FirstOrDefault();

            return View(instractor);
        }

        [HttpGet]
        public IActionResult edit (int id)
        {
            Instractor instractor = db.Instractors.ToList().FirstOrDefault( i => i.id == id);
            Departement departement = db.Departements.ToList().FirstOrDefault(d => d.id == instractor.dept_id);


            InstractorDepartementviewModel insd = new InstractorDepartementviewModel();
            insd.Id = id;
            insd.Ins_name = instractor.name;
            insd.Ins_address = instractor.address;
            insd.Ins_salary = instractor.salary;
            insd.Ins_dept = departement.id;
            insd.Ins_imag = instractor.imag;
            insd.departements = db.Departements.ToList();
            return View(insd);
        }

        [HttpPost]
        public IActionResult edit (Instractor instractor) {


            if(instractor.name != null)
            {
                var ins =  db.Instractors.ToList().Where( i => i.id == instractor.id).ToList().FirstOrDefault();
                ins.name = instractor.name;
                ins.address = instractor.address;
                ins.salary = instractor.salary;
                ins.dept_id= instractor.dept_id;
                db.Instractors.Update(ins);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            InstractorDepartementviewModel insd = new InstractorDepartementviewModel();
            insd.Id = instractor.id;
            insd.Ins_name = instractor.name;
            insd.Ins_address = instractor.address;
            insd.Ins_salary = instractor.salary;
            Departement departement = db.Departements.ToList().FirstOrDefault(d => d.id == instractor.dept_id);
            insd.Ins_dept = departement.id;
            insd.Ins_imag = instractor.imag;
            insd.departements = db.Departements.ToList();
            return View(insd);
        }

        public IActionResult setSession()
        {
            HttpContext.Session.SetString("Name", "Instractor");
            HttpContext.Session.SetInt32("age", 35);
            return Content($"session store");
        }

        public IActionResult getSession()
        {
            string name = HttpContext.Session.GetString("Name");
            int? age = HttpContext.Session.GetInt32("age");
            return Content($"name is {name} age = {age}");
        }

        public IActionResult getCoursesByDeptId(int deptId)
        {
            List<Course> courses = db.Courses.Where(c => c.dept_id == deptId).ToList();
            return Json(courses);   
        }
    }
}
