using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EducationCourse.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Boolean isAdmin { get; set; }

        

        public virtual ICollection<Course> Courses { get; set; }
       // public virtual ICollection<Role> Roles { get; set; }

        public Customer()
        {
            Courses = new HashSet<Course>();
            //Roles = new HashSet<Role>();
        }

        
    }
}