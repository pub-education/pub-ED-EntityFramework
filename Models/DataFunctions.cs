using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Linq;

namespace EntityFramework.Models
{
    public class DataFunctions
    {
        private EntityFrameworkContext _context { get; set; }

        public DataFunctions(EntityFrameworkContext ctx)
        {
            this._context = ctx;
        }

        public int AddPerson(IPerson person, string personType)
        {
            if (personType == "student")
            {
                this._context.Students.Add((Student)person);
            }
            else if (personType == "teacher")
            {
                this._context.Teachers.Add((Teacher)person);
            }

            return this._context.SaveChanges();
        }

        public int AddCourse(string courseName)
        {
            Course tmp = new Course();
            tmp.Name = courseName;
            this._context.Courses.Add(tmp);
            return this._context.SaveChanges();
        }

        public int AddAssignment(string assignment)
        {
            Assignment tmp = new Assignment();
            tmp.Name = assignment;
            this._context.Assignments.Add(tmp);
            return this._context.SaveChanges();
        }

        public int AddItemToCourse(int itemId, string itemType, int courseId)
        {
            Course tmpC = this._context.Courses.Find(courseId);

            if (itemType == "student")
            {
                Student stud = this._context.Students.Find(itemId);
                stud.Courses.Add(tmpC);
                tmpC.Students.Add(stud);
            }
            else if (itemType == "teacher")
            {
                Teacher teac = this._context.Teachers.Find(itemId);
                teac.Courses.Add(tmpC);
                tmpC.Teacher_id = itemId;
            }
            else if (itemType == "assignment")
            {
                Assignment ass = this._context.Assignments.Find(itemId);
                ass.Course_id = courseId;
                tmpC.Assignments.Add(ass);
            }

            return this._context.SaveChanges();
        }

        public List<IPerson> GetPersonList(string personType)
        {
            List<IPerson> retList;

            if (personType == "student")
            {
                IQueryable<Student> query = this._context.Students.OrderBy(m => m.LName);
                retList = query.ToList<IPerson>();
            }
            else if (personType == "teacher")
            {
                IQueryable<Teacher> query = this._context.Teachers.OrderBy(m => m.LName);
                retList = query.ToList<IPerson>();
            }
            else
            {
                retList = new List<IPerson>();
            }

            return retList;
        }

        public List<Course> GetCourseList()
        {
            IQueryable<Course> query = this._context.Courses.OrderBy(m => m.Name);
            return query.ToList<Course>();
        }

        public Course GetCourse(int id)
        {
            IQueryable query =this._context.Courses.Where(m => m.Id == id);
            return (Course)query;
        }

        public List<Assignment> GetAssignmentList(int courseId)
        {
            IQueryable<Assignment> query = this._context.Assignments.OrderBy(m => m.Name);
            return query.ToList<Assignment>();
        }

        public IPerson GetPerson(int id, string personType)
        {
            IQueryable query;
            if (personType == "student")
            {
                query = this._context.Students.Where(m => m.Id == id);
            }
            else
            {
                query = this._context.Teachers.Where(m => m.Id == id);
            }

            return (IPerson)query;
        }
    }
}
