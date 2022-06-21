using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_PRAC_1.Models
{
    public class LoginEmp
    { 
        [Required]
        [Key]
        public int UserId { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string Password { get; set; }

    }
}