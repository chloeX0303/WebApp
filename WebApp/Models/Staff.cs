using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class Staff
    {
        public int StaffID { get; set; }
        [Required(ErrorMessage = "Please enter your first name")]
        /*the user is required to enter the first name*/
        [Display(Name = "First Name")]
        /*"First Name" will be displayed instead of FirstName in the create/edit/detail form*/
        [MaxLength(25)]
        /*the length of the first name should be no more than 25 characters*/
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "No numbers and symbols")]
        /*this regular expression should prevent the user from creating a last name contanting numbers and symbols*/
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        /*"Middle Name" will be displayed instead of FirstName in the create/edit/detail form*/
        [MaxLength(25)]
        /*the first name will have the max length of 25 characters*/
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "No numbers and symbols")]
        /*this regular expression should prevent the user from creating a last name contanting numbers and symbols*/
        public string? MidName { get; set; } 
        /*'?' should null the midname*/
        [Required(ErrorMessage = "Please enter your last name")]
        /*the user is required to enter the last name*/
        [Display(Name = "Last Name")]
        /*"Last Name" will be displayed instead of FirstName in the create/edit/detail form*/
        [MaxLength(25)]
        /*the middle name will have the max length of 25 characters*/
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "No numbers and symbols")]
        /*this regular expression should prevent the user from creating a last name contanting numbers and symbols*/

        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter your email")]
        /*the user is required to enter the email*/
        [MaxLength(50)]
        /*the email will have the max length of 50 characters*/
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",
            ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your phone number")]
        /*the user is required to enter the phone number*/
        [Display(Name = "Phone Number")]
        /*"Phone Number" will be displayed instead of FirstName in the create/edit/detail form*/
        [MaxLength(14)]
        /*the email will have the max length of 14 characters*/
        [Range(0, int.MaxValue, ErrorMessage = "Numbers only")]
        /*[RegularExpression("^[0-9]+(-[0-9]+)+$", ErrorMessage = "Only 1 hyphen between numbers")]
        /*this should allow 1 hyphen between the number 
        This doesnt work so I comment it out*/
        public string PhoneNumber { get; set; }
        /*ImageName will be the title where the image link will be under in the staff table*/
        public string ImageName { get; set; }

        [NotMapped] 
        /*'ImageFile' wont have its own column in the staff table*/
        [DisplayName("Upload File")] 
        /*'Upload File' will be displayed in the create/edit/detail form instead of ImageFile*/
        public IFormFile ImageFile { get; set; }
       
    }
}
