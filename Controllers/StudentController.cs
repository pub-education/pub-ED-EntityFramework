using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFramework.Models;

namespace EntityFramework.Controllers
{
    public class StudentController : Controller
    {
        private DataFunctions _dataHandler;

        public StudentController(EntityFrameworkContext ctx) : base()
        {
            this._dataHandler = new DataFunctions(ctx);
        }
        private void SetTempData()
        {
            ViewData["Title"] = "Students Page";
            ViewData["PageHead"] = "Students";
            ViewData["Student"] = true;
            ViewData["Teacher"] = false;
            ViewData["Course"] = false;
            ViewBag.caller = "student";
        }

        public ActionResult Index()
        {
            SetTempData();
            //ViewData["List"] = this._dataHandler.GetPersonList("student");
            return View();
        }

        /// <summary>
        /// Adds a Student to the database
        /// </summary>
        /// <param name="collection">Input from form</param>
        /// <returns>View Index/Default or error view.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(IFormCollection collection)
        {
            try
            {
                SetTempData();
                Student tmp = new Student();
                tmp.FName = collection["fname"];
                tmp.LName = collection["lname"];
                this._dataHandler.AddPerson(tmp, "student");

                return View();
            }
            catch (Exception ex)
            {
                return View("Error"); ;
            }
        }


        [HttpGet]
        public ActionResult Add()
        {
            SetTempData();

            return View();
        }

        /// <summary>
        /// Adds a Student to a course
        /// </summary>
        /// <param name="collection">Input from form</param>
        /// <returns>View Index/Default or error view.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AssignToCourse(IFormCollection collection)
        {
            try
            {
                ViewData["StudentList"] = this._dataHandler.GetPersonList("student");
                //Edit DataFunctions.
                //ViewData["CourseList"] = this._dataHandler.GetPersonList("student");

                return View();
            }
            catch (Exception ex)
            {
                return View("Error"); ;
            }
        }
        [HttpGet]
        public ActionResult AssignToCourse()
        {
            SetTempData();
            return View();
        }


        [HttpGet]
        public ActionResult ListAll()
        {
            try
            {
                ViewData["List"] = this._dataHandler.GetPersonList("student");

                return View();
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
