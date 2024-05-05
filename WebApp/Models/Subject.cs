using System.Collections;

namespace WebApp.Models
{
    public class Subject
    {
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
