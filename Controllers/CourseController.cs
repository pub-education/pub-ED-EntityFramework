using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFramework.Models;

namespace EntityFramework.Controllers
{
    public class CourseController : Controller
    {
        private DataFunctions _dataHandler;

        public CourseController(EntityFrameworkContext ctx) : base()
        {
            this._dataHandler = new DataFunctions(ctx);
        }
        private void SetTempData()
        {
            ViewData["Title"] = "Course & Assignments Page";
            ViewData["PageHead"] = "Course & Assignments";
            ViewData["Student"] = false;
            ViewData["Teacher"] = false;
            ViewData["Course"] = true;
            ViewBag.caller = "course";
        }


        /// <summary>
        /// Adds a Course to the database
        /// </summary>
        /// <param name="collection">Input from form</param>
        /// <returns>View Add or error view.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCourse(IFormCollection collection)
        {
            try
            {
                SetTempData();
                this._dataHandler.AddCourse(collection["name"]);
                ViewData["CourseList"] = this._dataHandler.GetCourseList();

                return View();
            }
            catch (Exception ex)
            {
                return View("Error"); ;
            }
        }

        [HttpGet]
        public ActionResult AddCourse()
        {
            try
            {
                SetTempData();
                ViewData["CourseList"] = this._dataHandler.GetCourseList();

                return View();
            }
            catch (Exception ex)
            {
                return View("Error"); ;
            }
        }

        /// <summary>
        /// Adds an Assignment to the database
        /// </summary>
        /// <param name="collection">Input from form</param>
        /// <returns>View Add or error view.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAssignment(IFormCollection collection)
        {
            try
            {
                SetTempData();
                this._dataHandler.AddAssignment(collection["name"]);
                ViewData["AssignmentList"] = this._dataHandler.GetAssignmentList();

                return View();
            }
            catch (Exception ex)
            {
                return View("Error"); ;
            }
        }

        /// <summary>
        /// Adds an Assignment to the database
        /// </summary>
        /// <param name="collection">Input from form</param>
        /// <returns>View Add or error view.</returns>
        [HttpGet]
        public ActionResult AddAssignment()
        {
            try
            {
                SetTempData();
                ViewData["AssignmentList"] = this._dataHandler.GetAssignmentList();

                return View();
            }
            catch (Exception ex)
            {
                return View("Error"); ;
            }
        }

        /// <summary>
        /// Adds an Assignment to a course
        /// </summary>
        /// <param name="collection">Input from form</param>
        /// <returns>View Index/Default or error view.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AssignToCourse(IFormCollection collection)
        {
            try
            {
                int itemId = Convert.ToInt32(collection["assignmentId"]);
                int courseId = Convert.ToInt32(collection["courseId"]);
                this._dataHandler.AddItemToCourse(itemId, "assignment", courseId);
                ViewData["AssignmentList"] = this._dataHandler.GetAssignmentList();
                ViewData["CourseList"] = this._dataHandler.GetCourseList();

                return View();
            }
            catch (Exception ex)
            {
                return View("Error"); ;
            }
        }

        /// <summary>
        /// Adds an Assignment to a course
        /// </summary>
        /// <param name="collection">Input from form</param>
        /// <returns>View Index/Default or error view.</returns>
        [HttpGet]
        public ActionResult AssignToCourse()
        {
            try
            {
                ViewData["AssignmentList"] = this._dataHandler.GetAssignmentList();
                ViewData["CourseList"] = this._dataHandler.GetCourseList();

                return View();
            }
            catch (Exception ex)
            {
                return View("Error"); ;
            }
        }


        /// <summary>
        /// Lists the teacher, all Students and assignments that are assoiciated with a particular course.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ListAll(IFormCollection collection)
        {
            try
            {
                ViewData["CourseList"] = this._dataHandler.GetCourseList();
                int id = Convert.ToInt32(collection["courseId"]);
                Course course = this._dataHandler.GetCourse(id);
                ViewData["Course"] = course.Name;
                IPerson teach = this._dataHandler.GetPerson(course.Teacher_id, "teacher");
                ViewData["Teacher"] = (string)(teach.FName + " " + teach.LName);
                ViewData["PersonList"] = course.Students.ToList<IPerson>();
                ViewData["AssignmentList"] = course.Assignments;

                return View();
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        /// <summary>
        /// Lists the teacher, all Students and assignments that are assoiciated with a particular course.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ListAll()
        {
            try
            {
                ViewData["CourseList"] = this._dataHandler.GetCourseList();
                ViewData["Course"] = "";
                ViewData["Teacher"] = "";
                ViewData["PersonList"] = new List<IPerson>();
                ViewData["AssignmentList"] = new List<Assignment>();

                return View();
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
