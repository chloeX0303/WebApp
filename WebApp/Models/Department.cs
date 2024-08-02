using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace WebApp.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        [Required(ErrorMessage = "Please enter the department name")]
        /*the user is required to enter the department name*/
        [Display(Name = "Department Name")]
        /*the name "Department Name" will be displayed like this in the forms and tables in the app*/
        [MaxLength(30)]
        /*the department name will have the max length of 30 characters*/
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "No numbers and symbols")]
        /*this should stop numbers and symbols*/
        public string DepartmentName { get; set; }
        /*fix this---->*/
        public ICollection<Staff> Staffs { get; set;}
        public ICollection<Subject> Subjects { get; set; }
        /*this the title where the image link will be under in the department table*/
        public string ImageName { get; set; }
        [NotMapped]
        /*'ImageFile' wont have its own column in the department table*/
        [DisplayName("Upload File")]
        /*'Upload File' will be displayed in the create/edit/detail form instead of ImageFile*/
        public IFormFile ImageFile { get; set; }
    }
}
