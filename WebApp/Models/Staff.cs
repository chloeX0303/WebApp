using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Staff
    {
        public int StaffID { get; set; }
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
        public string? MidName { get; set; } /*'?' should null the midname*/
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
        [Required(ErrorMessage = "Please enter your phone number")]
        [Display(Name = "Phone Number")]
        [MaxLength(14)]
        [Range(0, int.MaxValue, ErrorMessage = "Numbers only")]
        /*[RegularExpression("^[0-9]+(-[0-9]+)+$", ErrorMessage = "Only 1 hyphen between numbers")]
        /*this should allow 1 hyphen between the number*/
        public string PhoneNumber { get; set; }
    }
}
