using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EducationCourse.Models
{
    public class CustomerLogin
    {
     
        public string Name { get; set; }

        
        public string Surname { get; set; }

        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class CustomerRegister
    {

        [Required]
        [Display(Name = "Email")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords didn't match")]
        public string ConfirmPassword { get; set; }

        [Required]
        public int Age { get; set; }
    }
}