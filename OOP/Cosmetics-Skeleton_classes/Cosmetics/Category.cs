using Bytes2you.Validation;
using Cosmetics.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cosmetics
{
    public class Category
    {
        private readonly string name;
        private readonly List<Product> products;

        public Category(string name)
        {
            Guard.WhenArgument(name, "category name").IsNull().Throw();
            Guard.WhenArgument(name.Length, "category name length").IsLessThan(2).IsGreaterThan(15).Throw();
            //if (name.Length < 2 || name.Length > 15)
            //{
            //    throw new ArgumentException("Category name must be between 2 and 15 sumbols!");
            //}
            this.products = new List<Product>();
            this.name = name;
        }

        public string Name => this.name;

        public List<Product> Products
        {
            get { return this.products; }
        }

        public virtual void AddProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException();
            }
            this.products.Add(product);
        }

        public virtual void RemoveProduct(Product product)
        {
            var containsProduct = this.products.Contains(product);

            if (!containsProduct)
            {
                throw new ArgumentNullException("Product now found!");
            }
            this.products.Remove(product);
        }

        public string Print()
        {
            var strBuilder = new StringBuilder();
            strBuilder.AppendLine($" #Category: {this.Name}");
            if (this.products.Count == 0)
            {
                strBuilder.Append("  #No product in this category");
                string emptyResultString = strBuilder.ToString();
                return emptyResultString;
            }
            foreach (var product in this.products.OrderBy(b => b.Name).ThenByDescending(p => p.Price))
            {
                strBuilder.AppendLine($" #{product.Name} {product.Brand}" + Environment.NewLine + 
                                    $" #Price: ${product.Price}" + Environment.NewLine + 
                                    $" #Gender: {product.Gender}" + Environment.NewLine + "===");
            }
           
            string result = strBuilder.ToString();
            return result;
        }
    }
}
