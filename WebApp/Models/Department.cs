using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        [Required(ErrorMessage = "Please enter the department name")]
        [Display(Name = "Department Name")]
        [MaxLength(30)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = "Numbers and symbols are not allowed.")]
        public string DepartmentName { get; set; }
        public ICollection<Staff> Staffs { get; set;}
    }
}
