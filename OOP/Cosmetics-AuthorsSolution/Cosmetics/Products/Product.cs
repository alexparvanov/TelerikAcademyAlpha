using Bytes2you.Validation;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public abstract class Product : IProduct
    {
        private readonly decimal price;
        private readonly string name;
        private readonly string brand;
        private readonly GenderType gender;

        public Product(string name, string brand, decimal price, GenderType gender)
        {
            Guard.WhenArgument(name, "ProductName").IsNull().Throw();
            Guard.WhenArgument(name.Length, "ProductName length").IsLessThan(3).IsGreaterThan(10).Throw();
            Guard.WhenArgument(brand, "ProductName").IsNull().Throw();
            Guard.WhenArgument(brand.Length, "Brand length").IsLessThan(2).IsGreaterThan(10).Throw();
            Guard.WhenArgument(price, "Price").IsLessThan(0).Throw();

            this.name = name;
            this.brand = brand;
            this.price = price;
            this.gender = gender;
        }
    
        public string Name => this.name;

        public string Brand => this.brand;

        public decimal Price => this.price;

        public GenderType Gender => this.gender;

        protected abstract string AdditionalInfo();

        public string Print()
        {
            return $" #{this.Name} {this.Brand}\r\n #Price: ${this.Price}\r\n #Gender: {this.Gender}\r\n{this.AdditionalInfo()}\r\n ===".Trim();
        }
    }
}
