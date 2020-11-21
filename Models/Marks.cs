using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace College_Management_System.Models
{
    public class Marks
    {
        public int ID { get; set; }
        public int StudentID { get; set; }
        public int SubjectID { get; set; }
        public int Score { get; set; }
        public virtual Student Student { get; set; }
        public virtual Subjects Subject { get; set; }
    }
}