using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace College_Management_System.Models
{
    public class Subjects
    {
        public int ID { get; set; }
        public string SubName { get; set; }
        public string Faculty { get; set; }
        public virtual ICollection<Marks> Marks { get; set; }
        public virtual Faculty Faculties { get; set; }


    }
}