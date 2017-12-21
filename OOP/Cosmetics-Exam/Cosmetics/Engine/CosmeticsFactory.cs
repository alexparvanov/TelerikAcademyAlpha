
using System;

namespace Cosmetics.Engine
{
    using System.Collections.Generic;

    using Cosmetics.Common;
    using Cosmetics.Contracts;
    using Cosmetics.Products;

    public class CosmeticsFactory : ICosmeticsFactory
    {
        private const int minIngredientNameLength = 4;
        private const int maxIngredientNameLength = 12;

        public ICategory CreateCategory(string name)
        {
            return new Category(name);
        }

        public IShampoo CreateShampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage)
        {
            return new Shampoo(name, brand, price, gender, milliliters, usage);
        }

        public IToothpaste CreateToothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients)
        {
            foreach (var ingredient in ingredients)
            {
                if (ingredient.Length < minIngredientNameLength || ingredient.Length > maxIngredientNameLength)
                {
                    throw new ArgumentException($"Each ingredient must be between {minIngredientNameLength} and {maxIngredientNameLength} symbols long!");
                }
            }

            return new Toothpaste(name, brand, price, gender, string.Join(", ", ingredients));
        }

        public IShoppingCart ShoppingCart()
        {
            return new ShoppingCart();
        }
    }
}
