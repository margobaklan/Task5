using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    abstract public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Country { get; set; }
        public DateTime DatePackage { get; set; }
        public string Details { get; set; }
        public Product(string Name, decimal Price, string Country, DateTime DatePackage, string Details)
        {
            this.Name = Name;
            this.Price = Price;
            this.Country = Country;
            this.DatePackage = DatePackage;
        }
        

    }

    class Groceries : Product
    {
        public DateTime Expiration { get; set; }
        public int Quantity{ get; set; }
        public string Unit { get; set; }
        public Groceries(string Name, decimal Price, string Country, DateTime DatePackage, string Details, DateTime Expiration, int Quantity, string Unit) : 
            base(Name, Price, Country, DatePackage, Details) 
        {
            this.Expiration = Expiration;
            this.Quantity = Quantity;
            this.Unit = Unit;
        }
        
    }

    class Book : Product
    {
        public int QuantityPages { get; set; }
        public string PublishingHouse { get; set; }
        public string Authors { get; set; }
        public Book(string Name, decimal Price, string Country, DateTime DatePackage, string Details, int QuantityPages, string PublishingHouse, string Authors) :
            base(Name, Price, Country, DatePackage, Details)
        {
            this.QuantityPages = QuantityPages;
            this.PublishingHouse = PublishingHouse;
            this.Authors = Authors;
        }
    }
}
