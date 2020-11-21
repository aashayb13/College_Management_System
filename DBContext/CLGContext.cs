using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using College_Management_System.Models;

namespace College_Management_System.DBContext
{
    public class CLGContext : DbContext
    {
        public CLGContext() : base("CLGContext")
        { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subjects> Subject { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Marks> Marks { get; set; }
    }

}