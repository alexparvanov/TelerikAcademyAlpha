using Bytes2you.Validation;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public class Toothpaste : Product, IToothpaste
    {
        private readonly string ingredients;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, string ingredients)
            : base(name, brand, price, gender)
        {
            Guard.WhenArgument(ingredients, "Ingredients").IsNull().Throw();
            this.ingredients = ingredients;
        }

        public string Ingredients => this.ingredients;

        protected override string AdditionalInfo()
        {
            return $" #Ingredients: {this.ingredients}";
        }
    }
}