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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }

    public class Student : IPerson
    {   
        public Student()
        {
            Courses = new List<Course>();
        }
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please, enter the first name.")]
        [MaxLength(45)]
        public string FName { get; set; }

        [Required(ErrorMessage = "Please, enter the last name.")]
        [MaxLength(45)]
        public string LName { get; set; }
        public List<Course> Courses { get; set; }
    }

    public class Teacher : IPerson
    {
        public Teacher()
        {
            Courses = new List<Course>();
        }
        [Key]
        public int Id { get; set; }

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
        public Course()
        {
            Students = new List<Student>();
            Assignments = new List<Assignment>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public int Teacher_id { get; set; }

        public int Grade { get; set; }

        public List<Student> Students { get; set; }
        public List<Assignment> Assignments { get; set; }
        [MaxLength(45)]
        [Required(ErrorMessage ="Please, enter a course name.")]
        public string Name { get; set; }
    }

    public class Assignment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Course_id { get; set; }

        [MaxLength(45)]
        [Required(ErrorMessage ="Please, name the assignment.")]
        public string Name { get; set; }

        public bool Completed { get; set; }
    }

    /// <summary>
    /// Interface for People type classes
    /// </summary>
    public interface IPerson
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
    }
}
