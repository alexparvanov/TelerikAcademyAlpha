using Bytes2you.Validation;
using Cosmetics.Common;
using System;

namespace Cosmetics.Products
{
    public class Product
    {
        private readonly decimal price;
        private readonly string name;
        private readonly string brand;
        private readonly GenderType gender;

        public Product(string name, string brand, decimal price, GenderType gender)
        {
            Guard.WhenArgument(name, "product name").IsNull().Throw();
            Guard.WhenArgument(name.Length, "product length").IsLessThan(3).Throw();
            Guard.WhenArgument(name.Length, "product length").IsGreaterThan(10).Throw();

            Guard.WhenArgument(brand, "brand name").IsNull().Throw();
            Guard.WhenArgument(brand.Length, "brand length").IsLessThan(2).Throw();
            Guard.WhenArgument(brand.Length, "brand length").IsGreaterThan(10).Throw();
           
            Guard.WhenArgument(price, "price").IsLessThan(0).Throw();
            
            //if (gender != GenderType.Men || gender != GenderType.Women || gender != GenderType.Unisex)
            //{
            //    throw new ArgumentException("Gender type selected is not available!");
            //}
            this.name = name;
            this.gender = gender;
            this.price = price;
            this.brand = brand;
        }

        public decimal Price => this.price;
        public string Name => this.name;
        public string Brand => this.brand;
        public GenderType Gender => this.gender;

        public string Print()
        {
            return $" #{this.Name} {this.Brand}\r\n #Price: ${this.Price}\r\n #Gender: {this.Gender}\r\n ===";
        }
    }
}
