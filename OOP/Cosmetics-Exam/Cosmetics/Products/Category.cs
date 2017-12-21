using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public class Category : ICategory
    {
        private const int minCategoryNameLength = 2;
        private const int maxCategoryNameLength = 15;

        private readonly string name;
        private readonly ICollection<IProduct> products;

        public Category(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Category name cannot be null!");
            }
            if (name.Length < minCategoryNameLength || name.Length > maxCategoryNameLength)
            {
                throw new ArgumentException($"Category name must be between {minCategoryNameLength} and {maxCategoryNameLength} symbols long!");
            }

            this.name = name;
            this.products = new List<IProduct>();
        }

        public ICollection<IProduct> Products => this.products;

        public string Name => this.name;

        public void AddCosmetics(IProduct product)
        {
            if (product == null)
            {
                throw new ArgumentNullException();
            }

            this.products.Add(product);
        }

        public void RemoveCosmetics(IProduct product)
        {
            if (product == null)
            {
                throw new ArgumentNullException();
            }

            var productFound = this.products.FirstOrDefault(x => x.Name == product.Name);

            if (productFound == null)
            {
                throw new ArgumentNullException($"Product {product.Name} does not exist in category {this.name}!");
            }

            this.products.Remove(productFound);
        }

        public string Print()
        {
            var strBuilder = new StringBuilder();
            strBuilder.AppendLine($"{this.Name} category - {this.Products.Count} " + (this.Products.Count > 1 || this.Products.Count == 0 ? "products" : "product") + " in total");

            foreach (var product in this.products.OrderBy(o => o.Brand).ThenByDescending(tb => tb.Price))
            {
                strBuilder.AppendLine(product.Print());
            }

            return strBuilder.ToString().TrimEnd();
        }
    }
}
