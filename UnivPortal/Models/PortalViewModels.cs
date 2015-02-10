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
       N, S, I, A
    }
    public class Student
    {
        [Display(Name = "StudentID")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [RegularExpression(@"/^[G]{1}[0-9]{6}$/", ErrorMessage = "Bad pattern! Try G followed by 6 digit.")]
        public int StudentID { get; set; }

        [Display(Name = "Last Name")]
        [RegularExpression(@"^[A-Z][-'a-zA-Z]{2,15}$", ErrorMessage = "Bad pattern! Alphabetic only and between 2 and 15 characters.")]
        public string LastName { get; set; }

        [Display(Name = "First Name")]
        [RegularExpression(@"^[A-Z][-'a-zA-Z]{2,15}$", ErrorMessage = "Bad pattern! Alphabetic only and between 2 and 15 characters.")]
        public string FirstName { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yy}", ApplyFormatInEditMode = true)]
        public DateTime DateofBirth { get; set; }

        [Display(Name = "Major ID")]
        [RegularExpression(@"^[A-Z]{2,5}$", ErrorMessage = "Bad pattern! Please contact administrator.")]
        public String MajorID { get; set; }

        [Display(Name = "Email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",ErrorMessage="Invalid email address format.")]
        public String Email { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual Major Majors { get; set; }
    }



    public class Instructor
    {
        [Display(Name = "Instructor ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [RegularExpression(@"/^[G]{1}[0-9]{6}$/", ErrorMessage = "Bad pattern! Try G followed by 6 digits.")]
        public int InstrutorID { get; set; }

        [Display(Name = "Last Name")]
        [RegularExpression(@"^[A-Z][-'a-zA-Z]{2,15}$", ErrorMessage = "Bad pattern! Alphabetic only and between 2 and 15 characters.")]
        public string LastName { get; set; }

        [Display(Name = "Last Name")]
        [RegularExpression(@"^[A-Z][-'a-zA-Z]{2,15}$", ErrorMessage = "Bad pattern! Alphabetic only and between 2 and 15 characters.")]
        public string FirstName { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yy}", ApplyFormatInEditMode = true)]
        public DateTime DateofBirth { get; set; }

        [Display(Name = "Email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Invalid email address format.")]
        public String Email { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

        public virtual ICollection<Department> Departments { get; set; }
    }
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Course ID")]
        [RegularExpression(@"^[A-Z]{2,5}[0-9]{3}$", ErrorMessage = "Bad pattern! 2 to 5 upper Char followed by 3 digits.")]
        public String CourseID { get; set; }

        [Display(Name = "Course Name")]
        [RegularExpression(@"^[\w]{1}[-'\s\w]{2,30}+$", ErrorMessage = "Bad pattern! Character between 2 and 30.  char, - and ' allowed only")]
        public String Name { get; set; }

        [Display(Name = "Course Description")]
        [RegularExpression(@"^[\w]{1}[-'\s\w]{2,30}+$", ErrorMessage = "Bad pattern! Alphabetic only and between 2 and 50 characters.")]
        public String Description { get; set; }

        [Display(Name = "Department")]
        [RegularExpression(@"/^[A-Z]{2,5}$/", ErrorMessage = "Bad pattern! Try [2 -5] Caracters UPPER Case.")]
        public String DepartmentID { get; set; }

        [Display(Name = "Number of Credits")]
        [Range(0, 3)]
        public int Credit { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; }

    }
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public String CourseID { get; set; }
        public String StudentID { get; set; }

        [DisplayFormat(NullDisplayText = "No grade")]
        public Grade? Grade { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
    public class Department
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Department ID")]
        [RegularExpression(@"^[A-Z]{2,5}$", ErrorMessage = "Bad pattern! 2 to 5 upper Char.")]
        public String DepartmentID { get; set; }

        [Display(Name = "Name")]
        [RegularExpression(@"^[\w]{1}[-'\s\w]{2,15}+$", ErrorMessage = "Bad pattern! Character between 2 and 15.  char, - and ' allowed only")]
        public String Name { get; set; }

        public int? InstructorID { get; set; }

        public virtual Instructor Administrator { get; set; }
        public virtual ICollection<Major> Majors { get; set; }

    }
    public class Major
    {
        [Display(Name = "Major ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [RegularExpression(@"^[A-Z]{2,5}$", ErrorMessage = "Bad pattern! Pattern SWE, CS, ISA, IT ...")]
        public String MajorID { get; set; }

        [Display(Name = "Name")]
        [RegularExpression(@"^[\w]{1}[-'\s\w]{2,15}+$", ErrorMessage = "Bad pattern! Character between 2 and 15.  char, - and ' allowed only")]
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