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
        [MaxLength(15, ErrorMessage= "the length of the first name should be no more than 15 characters")]
        /*the length of the first name should be no more than 15 characters*/
        [MinLength(2, ErrorMessage= "the length of the first name should be at least 2 characters")]
        /* the length of the first name should be at least 2 characters*/
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "No numbers and symbols")]
        /*this regular expression should prevent the user from creating a last name containing numbers and symbols*/
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        /*"Middle Name" will be displayed instead of FirstName in the create/edit/detail form*/
        [MaxLength(15, ErrorMessage = "the length of the middle name should be no more than 15 characters")]
        /* the length of the mid name should be no more than 15 characters*/
        [MinLength(2, ErrorMessage = "the middle name should have at least 2 characters")]
        /*the middle name should have at least 2 characters*/
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "No numbers and symbols")]
        /*this regular expression should prevent the user from creating a last name containing numbers and symbols*/
        public string? MidName { get; set; }
        /*'?' should null the midname*/
        [Required(ErrorMessage = "Please enter your last name")]
        /*the user is required to enter the last name*/
        [Display(Name = "Last Name")]
        /*"Last Name" will be displayed instead of FirstName in the create/edit/detail form*/
        [MaxLength(15, ErrorMessage = "the last name will have the max length of 15 characters")]
        /*the last name will have the max length of 15 characters*/
        [MinLength(2, ErrorMessage = "the last name will have at least 2 characters")]
        /*the last name will have at least 2 characters*/
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "No numbers and symbols")]
        /*this regular expression should prevent the user from creating a last name containing numbers and symbols*/

        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter your email")]
        /*the user is required to enter the email*/
        [MaxLength(25, ErrorMessage = "the email will have no more than 50 characters")]
        /*the email will have no more than 25 characters*/
        [MinLength(20, ErrorMessage = "the email will have at least 20 characters")]
        /*the email will have at least 20 characters*/
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",
            ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your phone number")]
        /*the user is required to enter the phone number*/
        [Display(Name = "Phone Number")]
        /*"Phone Number" will be displayed instead of FirstName in the create/edit/detail form*/
        [MaxLength(11, ErrorMessage = "the email will have the max length of 11 characters")]
        /*the email will have the max length of 11 characters*/
        [MinLength(10, ErrorMessage = "the email will have at least 10 characters")]
        /*the email will have the at least 10 characters*/
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
