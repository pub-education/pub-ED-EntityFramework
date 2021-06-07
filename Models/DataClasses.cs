using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace EntityFramework.Models
{
    public class Student
    {
        public int Student_id { get; set; }
        [Required(ErrorMessage = "Please, enter the first name.")]
        public string FName { get; set; }
        [Required(ErrorMessage = "Please, enter the last name.")]
        public string LName { get; set; }
    }

    public class Teacher
    {
        public int Teacher_id { get; set; }
        [Required(ErrorMessage ="Please, enter the first name.")]
        public string FName { get; set; }
        [Required(ErrorMessage = "Please, enter the last name.")]
        public string LName { get; set; }
    }

    public class Course
    {
        public int Course_id { get; set; }

        [Required(ErrorMessage ="Please, enter a course name.")]
        public string Name { get; set; }
    }

    public class Assignment
    {
        public int Assignment_id { get; set; }
        [Required(ErrorMessage ="Please, name the assignment.")]
        public string Name { get; set; }
    }

    public class Students
    {
        public List<Student> StudentList { get; set; }
    }
    public class Teachers
    {
        public List<Teacher> TeacherList { get; set; }
    }
    public class Courses
    {
        public List<Course> CourseList { get; set; }
    }
    public class Assignments
    {
        public List<Assignment> AssignmentList { get; set; }
    }
}
