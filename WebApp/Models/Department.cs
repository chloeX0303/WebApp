using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        [Display(Name = "Department Name")]
        [MaxLength(30)]
        public string DepartmentName { get; set; }
        public ICollection<Staff> Staffs { get; set;}
    }
}
