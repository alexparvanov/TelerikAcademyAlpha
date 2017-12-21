using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public class Shampoo : Product, IShampoo
    {
        private readonly uint milliliters;
        private readonly UsageType usage;

        public Shampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage)
            : base(name, brand, price, gender)
        {
            this.milliliters = milliliters;
            this.usage = usage;
        }

        public uint Milliliters => this.milliliters;

        public UsageType Usage => this.usage;

        protected override string AdditionalInfo()
        {
            return $" #Milliliters: {this.Milliliters}\r\n #Usage: {this.Usage}";
        }
    }
}
