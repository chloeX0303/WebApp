using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Subject
    {
        public int SubjectID { get; set; }
        [Required(ErrorMessage = "Please enter the subject name")]
        [Display(Name = "Subject Name")]
        [MaxLength(30)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = "Numbers and symbols are not allowed.")]
        public string SubjectName { get; set; }
       
    }
}
