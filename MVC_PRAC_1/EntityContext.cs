using MVC_PRAC_1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_PRAC_1
{
    public class EntityContext : DbContext
    {
        public EntityContext() : base("MvcPractice")
        {

        }
        public DbSet<ProductsIvy> ProductsIvys { get; set; }
        public DbSet<Customer_Details> CustomerDetailsIvys { get; set;}
    }
}