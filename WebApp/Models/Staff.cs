using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Staff
    {
        public int StaffID { get; set; }
        [Required(ErrorMessage = "Please enter your first name")]
        [Display(Name = "First Name")]
        [MaxLength(25)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your last name")]
        [Display(Name = "Last Name")]
        [MaxLength(25)]
        public string LastName { get; set;}
        [Required(ErrorMessage = "Please enter your email")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your phone number")]
        [Display(Name = "Phone Number")]
        [MaxLength(14)]
        [Range(0, int.MaxValue, ErrorMessage = "Numbers only")]
        public string PhoneNumber { get; set; }
    }
}
