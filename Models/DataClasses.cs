using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EntityFramework.Models
{

    public class EntityFrameworkContext : DbContext
    {
        public EntityFrameworkContext(DbContextOptions<EntityFrameworkContext> options)
            : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
    }
    public class Student
    {
        [Key]
        public int Student_id { get; set; }

        [Required(ErrorMessage = "Please, enter the first name.")]
        [MaxLength(45)]
        public string FName { get; set; }

        [Required(ErrorMessage = "Please, enter the last name.")]
        [MaxLength(45)]
        public string LName { get; set; }
        public List<Course> Courses { get; set; }
    }

    public class Teacher
    {
        [Key]
        public int Teacher_id { get; set; }

        [MaxLength(45)]
        [Required(ErrorMessage ="Please, enter the first name.")]
        public string FName { get; set; }

        [MaxLength(45)]
        [Required(ErrorMessage = "Please, enter the last name.")]
        public string LName { get; set; }
        [Required]
        public List<Course> Courses { get; set; }
    }

    public class Course
    {
        [Key]
        public int Course_id { get; set; }
        [Required]
        public int Teacher_id { get; set; }

        public List<Student> Students { get; set; }
        public List<Assignment> Assignments { get; set; }
        [MaxLength(45)]
        [Required(ErrorMessage ="Please, enter a course name.")]
        public string Name { get; set; }
    }

    public class Assignment
    {
        [Key]
        public int Assignment_id { get; set; }
        [Required]
        public int Course_id { get; set; }

        [MaxLength(45)]
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
