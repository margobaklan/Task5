using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    abstract public class Product
    {
        public decimal Price = 0;// { get; set; }
        public string Name = "--"; //{ get; set; }
        public string Country = "--";// { get; set; }
        public DateTime DatePackage = new DateTime(2000, 7, 20);// { get; set; }
        public Product(string Name)
        {
            this.Name = Name;
        }
        public string Details { get; set; }

    }

    class Groceries : Product
    {
        public DateTime Expiration = new DateTime(2000, 7, 20);// { get; set; }
        public int Quantity = 0;// { get; set; }
        public string Unit = "--"; // { get; set; }
        public Groceries(string name) : base(name) { }
        
    }

    class Book : Product
    {
        public int QuantityPages = 0;// { get; set; }
        public string PublishingHouse = "--"; // { get; set; }
        public string Authors = "--"; // { get; set; }
        public Book(string name) : base(name) { }
    }
}
