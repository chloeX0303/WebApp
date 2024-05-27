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
       
        public string SubjectName { get; set; }
       
    }
}
