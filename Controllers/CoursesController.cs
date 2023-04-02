using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ITI_Project.Models;
using ITI_Project.reprosatories;

namespace ITI_Project.Controllers
{
    public class CoursesController : Controller
    {
        ICourseReprosatory courseReprosatory;
        IDepartementReprosatory departementReprosatory;
        public CoursesController(IConfiguration config , ICourseReprosatory courseReprosatory , IDepartementReprosatory departementReprosatory)
        {
            this.courseReprosatory = courseReprosatory;
            this.departementReprosatory = departementReprosatory;
        }

        // GET: Courses
        public  IActionResult Index()
        {
            List<Course> courses = courseReprosatory.getAll();
            return View(courses);
        }

        public IActionResult minDegree(double min_degree , double degree)
        {
            if (min_degree < degree)
                return Json(true);
            else
                return Json(false);
        }
        // GET: Courses/Details/5
        public  IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Course course = courseReprosatory.getDetails(id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            ViewData["departements"] = new SelectList(departementReprosatory.getAll(), "id", "name");
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Create([Bind("Id,name,degree,min_degree,dept_id")] Course course)
        {
            if (ModelState.IsValid)
            {
                courseReprosatory.addCourse(course);
                return RedirectToAction(nameof(Index));
            }
            ViewData["departements"] = new SelectList(departementReprosatory.getAll(), "id", "name", course.dept_id);
            return View(course);
        }

        // GET: Courses/Edit/5
        public  IActionResult Edit(int? id)
        {
            if (id == null || courseReprosatory.getAll() == null)
            {
                return NotFound();
            }

            var course = courseReprosatory.findCourse(id);
            if (course == null)
            {
                return NotFound();
            }
            ViewData["dept_id"] = new SelectList(departementReprosatory.getAll(), "id", "id", course.dept_id);
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit(int id, [Bind("Id,name,degree,min_degree,dept_id")] Course course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   courseReprosatory.editCourse(course);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!courseReprosatory.courseExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["dept_id"] = new SelectList(departementReprosatory.getAll(), "id", "id", course.dept_id);
            return View(course);
        }

        // GET: Courses/Delete/5
        public  IActionResult Delete(int? id)
        {
            if (id == null || courseReprosatory.getAll() == null)
            {
                return NotFound();
            }

            var course = courseReprosatory.getDetails(id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  IActionResult DeleteConfirmed(int id)
        {
            if (courseReprosatory.getAll() == null)
            {
                return Problem("Entity set 'CourseSystem.Courses'  is null.");
            }
            courseReprosatory.delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
          return true;
        }
    }
}
