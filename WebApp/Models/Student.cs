using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        [Required(ErrorMessage = "Please enter your first name")]
        /*no allowed to leave this the firstname empty*/
        [Display(Name = "First Name")]
        /*on the website it will be displayed as First Name*/
        [MaxLength(15)]
        /*the maximum amount of characters allowed for a first name is 15*/
        [MinLength(2, ErrorMessage = "the first name will at least 2 character")]
        /*the first name should have the minimum length of 3 characters*/
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "No numbers and symbols")]
        /*this should stop numbers and symbols*/
        public string FirstName { get; set; }
        /*on the website it will be displayed as Middle Name*/
        [Display(Name = "Middle Name")]
        [MaxLength(15)]
        /*the maximum amount of characters allowed for a mid name is 15*/
        [MinLength(2, ErrorMessage = "the mid name will at least 2 character")]
        /*the mid name should have the minimum length of 3 characters*/
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "No numbers and symbols")]
        /*this should stop numbers and symbols*/
        public string? MidName { get; set; }
        [Required(ErrorMessage = "Please enter your last name")]
        /*no allowed to leave this the lastname empty*/
        [Display(Name = "Last Name")]
        /*on the website it will be displayed as Last Name*/
        [MaxLength(15)]
        /*the maximum amount of characters allowed for a last name is 15*/
        [MinLength(2, ErrorMessage = "the last name will at least 2 character")]
        /*the last name should have the minimum length of 3 characters*/
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "No numbers and symbols")]
        /*this should stop numbers and symbols*/

        public string LastName { get; set;}
        [Required(ErrorMessage = "Please enter your email")]
        /*the user is required to enter the email*/
        [MaxLength(25, ErrorMessage = "the email will have no more than 25 characters")]
        /*the email will have no more than 50 characters*/
        [MinLength(20, ErrorMessage = "the email will have at least 20 characters")]
        /*the email will have at least 20 characters*/
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",
            ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }
    }
}
