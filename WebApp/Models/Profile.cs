namespace WebApp.Models
{
    public class Profile
    {
        public int ProfileID { get; set; }
        public ICollection<Staff> Staffs { get; set;}
    }
}
