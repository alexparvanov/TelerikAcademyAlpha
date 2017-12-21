using System;
using System.ComponentModel;
using Bytes2you.Validation;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public class Product : IProduct
    {
        private readonly string name;
        private readonly string brand;
        private readonly decimal price;
        private readonly GenderType gender;

        public Product(string name, string brand, decimal price, GenderType gender)
        {
            Guard.WhenArgument(name, "product name").IsNull().Throw();
            Guard.WhenArgument(name.Length, "product name length").IsLessThan(3).IsGreaterThan(10).Throw();
            this.name = name;

            Guard.WhenArgument(brand, "brand name").IsNull().Throw();
            Guard.WhenArgument(brand.Length, "brand name length").IsLessThan(2).IsGreaterThan(10).Throw();

            this.brand = brand;

            Guard.WhenArgument(price, "price value").IsLessThan(0).Throw();

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
            return $"#{this.name} {this.brand}" + Environment.NewLine +
                   $" #Price: ${this.price}" + Environment.NewLine +
                   $" #Gender: {this.gender}";
        }
    }
}
