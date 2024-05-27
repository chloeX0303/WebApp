﻿using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        [Required(ErrorMessage = "Please enter the department name")]
        [Display(Name = "Department Name")]
        [MaxLength(30)]
       
        public string DepartmentName { get; set; }
        public ICollection<Staff> Staffs { get; set;}
        public ICollection<Subject> Subjects { get; set; }
    }
}
