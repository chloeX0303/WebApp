using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Subject
    {
        public int SubjectID { get; set; }
        [Display(Name = "Subject Name")]
        [MaxLength(30)]
        public string SubjectName { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
