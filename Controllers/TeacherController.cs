using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFramework.Models;

namespace EntityFramework.Controllers
{
    public class TeacherController : Controller
    {
        private DataFunctions _dataHandler;

        public TeacherController(EntityFrameworkContext ctx) : base()
        {
            this._dataHandler = new DataFunctions(ctx);
        }
        private void SetTempData()
        {
            ViewData["Title"] = "Students Page";
            ViewData["PageHead"] = "Students";
            ViewData["Student"] = false;
            ViewData["Teacher"] = true;
            ViewData["Course"] = false;
            ViewBag.caller = "teacher";
        }
        

        /// <summary>
        /// Adds a Teacher to the database
        /// </summary>
        /// <param name="collection">Input from form</param>
        /// <returns>View Add or error view.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(IFormCollection collection)
        {
            try
            {
                SetTempData();
                Teacher tmp = new Teacher();
                tmp.FName = collection["fname"];
                tmp.LName = collection["lname"];
                this._dataHandler.AddPerson(tmp, "teacher");

                return View();
            }
            catch (Exception ex)
            {
                return View("Error"); ;
            }
        }

        /// <summary>
        /// Adds a Teacher to a course
        /// </summary>
        /// <param name="collection">Input from form</param>
        /// <returns>View Index/Default or error view.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddToCourse(IFormCollection collection)
        {
            try
            {
                ViewData["TeacherList"] = this._dataHandler.GetPersonList("teacher");
                //Edit DataFunctions.
                //ViewData["CourseList"] = this._dataHandler.GetPersonList("teacher");

                return View();
            }
            catch (Exception ex)
            {
                return View("Error"); ;
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ListAll(IFormCollection collection)
        {
            try
            {
                ViewData["List"] = this._dataHandler.GetPersonList("teacher");

                return View();
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
