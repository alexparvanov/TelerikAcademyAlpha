using System;
using System.ComponentModel;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public class Product : IProduct
    {
        private const int minNameLength = 3;
        private const int maxNameLength = 10;
        private const int minBrandNameLength = 2;
        private const int maxBrandNameLength = 10;
        private readonly string name;
        private readonly string brand;
        private readonly decimal price;
        private readonly GenderType gender;

        public Product(string name, string brand, decimal price, GenderType gender)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(brand))
            {
                throw new ArgumentNullException("Cannot be null!");
            }

            if (name.Length < minNameLength || name.Length > maxNameLength)
            {
                throw new ArgumentException($"Product name must be between {minNameLength} and {maxNameLength} symbols long!");
            }
           
            this.name = name;

            if (brand.Length < minBrandNameLength || brand.Length > maxBrandNameLength)
            {
                throw new ArgumentException($"Product brand must be between {minBrandNameLength} and {maxBrandNameLength} symbols long!");
            }
           
            this.brand = brand;

            if (price < 0)
            {
                throw new ArgumentException("Price cannot be negative!");
            }

            this.price = price;

            if (gender == GenderType.Men || gender == GenderType.Unisex || gender == GenderType.Women)
            {
                this.gender = gender;
            }
            else
            {
                throw new InvalidEnumArgumentException();
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }
        public string Brand
        {
            get
            {
                return this.brand;
            }
        }
        public decimal Price
        {
            get
            {
                return this.price;
            }
        }
        public GenderType Gender
        {
            get
            {
                return this.gender;
            }
        }

        public virtual string Print()
        {
            return $"- {this.Brand} - {this.Name}:" + Environment.NewLine +
                   $"  * Price: ${this.Price}" + Environment.NewLine +
                   $"  * For gender: {this.Gender}";
        }
    }
}
