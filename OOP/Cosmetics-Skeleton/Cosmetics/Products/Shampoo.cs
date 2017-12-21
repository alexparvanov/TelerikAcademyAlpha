using Bytes2you.Validation;
using Cosmetics.Common;
using Cosmetics.Contracts;
using System;
using System.ComponentModel;

namespace Cosmetics.Products
{
    public class Shampoo : Product, IShampoo
    {
        private readonly uint milliliters;
        private readonly UsageType usage;

        public Shampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage) : base(name, brand, price, gender)
        {
            this.milliliters = milliliters;


            if (usage == UsageType.EveryDay || usage == UsageType.Medical)
            {
                this.usage = usage;
            }
            else
            {
                throw new InvalidEnumArgumentException();
            }

        }

        public uint Milliliters
        {
            get { return this.milliliters; }
        }
        public UsageType Usage
        {
            get { return this.usage; }
        }

        public override string Print()
        {
            return base.Print() + Environment.NewLine +
                $" #Milliliters: {this.milliliters}" + Environment.NewLine +
                $" #Usage: {this.usage}";
        }
    }
}
