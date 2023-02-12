using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {

        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }

        public List<Order> Orders { get; set; }
        public Product()
        {
            
        }
        public Product(int id, string name,string productname)
        {
            Id = id;
            CategoryName = name;
            ProductName= productname;
        }
    }

    public enum ProductCategory
    {
        Smartphone,
        Computer,
        TV
    };
}