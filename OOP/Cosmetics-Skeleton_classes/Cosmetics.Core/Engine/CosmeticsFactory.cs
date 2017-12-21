using Cosmetics.Cart;
using Cosmetics.Common;
using Cosmetics.Products;
using System;

namespace Cosmetics.Core.Engine
{
    public class CosmeticsFactory
    {
        public Category CreateCategory(string name)
        {
            return new Category(name);
        }

        public Product CreateProduct(string name, string brand, decimal price, string gender)
        {
            Product product = new Product(name, brand, price, (GenderType)Enum.Parse(typeof(GenderType), gender));
            return product;
        }

        public ShoppingCart ShoppingCart()
        {
            return new ShoppingCart();
        }
    }
}
