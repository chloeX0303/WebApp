using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        [Required(ErrorMessage = "Please enter your first name")]
        [Display(Name = "First Name")]
        [MaxLength(25)]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "No numbers")]
        /*this should stop numbers*/
        public string FirstName { get; set; }
        
        [Display(Name = "Middle Name")]
        [MaxLength(25)]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "No numbers")]
        /*this should stop numbers*/
        public string MidName { get; set; }
        [Required(ErrorMessage = "Please enter your last name")]
        [Display(Name = "Last Name")]
        [MaxLength(25)]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "No numbers")]
        /*this should stop numbers*/

        public string LastName { get; set;}
        [Required(ErrorMessage = "Please enter your email")]
        [MaxLength(50)]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",
            ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }
    }
}
