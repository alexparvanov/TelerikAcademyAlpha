using System;
using System.Collections.Generic;
using System.Linq;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly ICollection<IProduct> productList;

        public ShoppingCart()
        {
            this.productList = new List<IProduct>();
        }

        public ICollection<IProduct> ProductList
        {
            get { return this.productList; }
        }

        public void AddProduct(IProduct product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("Argument is null");
            }

            this.productList.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("Argument is null");
            }

            this.productList.Remove(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("Argument is null");
            }
            
            return this.productList.Any(x => x.Name == product.Name);
        }

        public decimal TotalPrice()
        {
            return this.productList.Sum(x => x.Price);
        }
    }
}
