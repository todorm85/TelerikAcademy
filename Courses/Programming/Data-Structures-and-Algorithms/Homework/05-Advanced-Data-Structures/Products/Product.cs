namespace Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Product : IComparable<Product>
    {
        public override string ToString()
        {
            return $"{this.Name}: {this.Price}";
        }
        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CompareTo(Product other)
        {
            return (int)((this.Price - other.Price) % int.MaxValue);
        }
    }
}
