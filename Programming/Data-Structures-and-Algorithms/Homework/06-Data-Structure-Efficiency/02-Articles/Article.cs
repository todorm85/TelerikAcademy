using System;

namespace _02_Articles
{
    public class Article : IComparable<Article>
    {
        public Article(string title, string barcode, string vendor, decimal price)
        {
            this.Barcode = barcode;
            this.Title = title;
            this.Price = price;
            this.Vendor = vendor;
        }

        public string Barcode { get; set; }

        public string Title { get; set; }

        public string Vendor { get; set; }

        public decimal Price { get; set; }

        public int CompareTo(Article other)
        {
            if (other.Barcode == this.Barcode && other.Title == this.Title && other.Vendor == this.Vendor && other.Price == this.Price)
            {
                return 0;
            }

            if (other.Price<this.Price)
            {
                return 1;
            }

            return -1;
        }
    }
}