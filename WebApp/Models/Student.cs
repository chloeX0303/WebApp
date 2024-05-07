using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        [Display(Name = "First Name")]
        [MaxLength(25)]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [MaxLength(25)]
        public string LastName { get; set;}
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }
    }
}
