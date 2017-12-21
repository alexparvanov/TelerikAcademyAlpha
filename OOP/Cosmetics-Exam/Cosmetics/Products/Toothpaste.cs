using System;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public class Toothpaste : Product, IToothpaste
    {
        private readonly string ingredients;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, string ingredients) : base(name, brand, price, gender)
        {
            if (ingredients == null)
            {
                throw new ArgumentNullException("Cannot be null!");
            }

            this.ingredients = ingredients;
        }

        public string Ingredients
        {
            get { return this.ingredients; }
        }

        public override string Print()
        {
            return base.Print() + Environment.NewLine +
                   $"  * Ingredients: {this.Ingredients}";
        }
    }
}
