using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_PRAC_1.Models
{
    public class ProductsIvy
    {
        public int Id { get; set; }
        [Key]
        [Required]
        public int Product_Id { get; set; }
        [Required]
        public string Product_Name { get; set; }
        [Required]
        public double Product_Price { get; set; }
        [Required]
        public DateTime Product_Manufacturing_date { get; set; }
        [Required]
        public DateTime Product_Expiry_date { get; set; }

    }
}