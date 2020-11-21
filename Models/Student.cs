using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace College_Management_System.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string Branch { get; set; }
        public int Semester { get; set; }
        public virtual ICollection<Marks> Marks { get; set; }
    }
}