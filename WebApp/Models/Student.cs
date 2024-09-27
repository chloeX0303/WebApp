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
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "No numbers and symbols")]
        /*this should stop numbers and symbols*/
        public string FirstName { get; set; }
        /*on the website it will be displayed as Middle Name*/
        [Display(Name = "Middle Name")]
        [MaxLength(15)] 
        /*the maximum amount of characters allowed for a mid name is 15*/
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "No numbers and symbols")]
        /*this should stop numbers and symbols*/
        public string? MidName { get; set; }
        [Required(ErrorMessage = "Please enter your last name")]
        /*no allowed to leave this the lastname empty*/
        [Display(Name = "Last Name")]
        /*on the website it will be displayed as Last Name*/
        [MaxLength(15)]
        /*the maximum amount of characters allowed for a last name is 15*/
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "No numbers and symbols")]
        /*this should stop numbers and symbols*/

        public string LastName { get; set;}
        /*no allowed to leave this the email empty*/
        [Required(ErrorMessage = "Please enter your email")]
        [MaxLength(25)]
        /*the maximum amount of characters allowed for a gmail is 15*/
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",
            ErrorMessage = "Email is not valid.")]
        /*the user needs to add @ and .com for it to be an email.*/
        public string Email { get; set; }
    }
}
