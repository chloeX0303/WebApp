using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class Subject
    {
        public int SubjectID { get; set; }
        [Required(ErrorMessage = "Please enter the subject name")]
        /*the user is required to enter the subject name*/
        [Display(Name = "Subject Name")]
        /*the name "Subject Name" will be displayed like this in the forms and tables in the web*/
        [MaxLength(30)]
        /*the subject name will have the max length of 30 characters*/
        [MinLength(3, ErrorMessage ="the subject name should have at least 3 characters")]
        /*the subject name should have the minimum length of 3 characters*/
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "No numbers and symbols")]
        /*this should stop numbers and symbols*/
        public string SubjectName { get; set; }
        /*ImageName will be the title where the image link will be under in the staff table*/
        public string ImageName { get; set; }
        [NotMapped]
        /*'ImageFile' wont have its own column in the subject table*/
        [DisplayName("Upload File")]
        /*'Upload File' will be displayed in the create/edit/detail form instead of ImageFile*/
        public IFormFile ImageFile {  get; set; }
     
    }
}
