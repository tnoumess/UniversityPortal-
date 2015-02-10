using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UnivPortal.Models
{

    public enum Grade
    {
        A, B, C, D, F
    }
    public enum Role
    {
        S, I, A
    }
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime DateofBirth { get; set; }
        public String MajorID { get; set; }
        public String Email { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
    public class Instructor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InstrutorID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime DateofBirth { get; set; }
        public String DepartmentID { get; set; }
        public String Email { get; set; }
    }
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public String CourseID { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public int DepartmentID { get; set; }
        public int Credit { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; }

    }
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
    public class Department
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public String DepartmentID { get; set; }
        public String Name { get; set; }
        public virtual Instructor Administrator { get; set; }
        public virtual ICollection<Major> Majors { get; set; }

    }
    public class Major
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public String MajorID { get; set; }
        public String Name { get; set; }
        public virtual ICollection<Course> Listcourses { get; set; }
    }
   
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public String Email;
        public String Password;
        public Role? Role { get; set; }
    }

    public class RegisterUser
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}