using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public int InstrutorID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime DateofBirth { get; set; }
        public String DepartmentID { get; set; }
        public String Email { get; set; }
    }
    public class Course
    {

    }
    public class Enrollment
    {

    }
    public class Department
    {
        public String DepartmentID { get; set; }
        public String Name { get; set; }
        public virtual ICollection<Major> Majors { get; set; }

    }
    public class Major
    {
        public String MajorID { get; set; }
        public String Name { get; set; }
        public virtual ICollection<Course> Listcourses { get; set; }
    }
    public class Admin
    {

    }


    public class User
    {
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