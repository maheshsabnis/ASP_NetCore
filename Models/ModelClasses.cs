using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Core_WebApp.Models
{
    public class Category
    {
        [Key]
        public int CategoryRowId { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int BasePrice { get; set; }
    }
    public class Manufacturer
    {
        [Key]
        public int ManufacturerRowId { get; set; }
        public string ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
    }

    public class Product
    {
        [Key]
        public int ProductRowId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int CategoryRowId { get; set; } // foreign Key
        public int ManufacturerRowId { get; set; } // foreign Key
        public Category Category { get; set; } // one-to-many relationship
        public Manufacturer Manufacturer { get; set; } // one-to-many relationship
    }
}
