using System;
using System.Text.RegularExpressions;
using Dealership.Common.Enums;
using Dealership.Contracts;

namespace Dealership.Models
{
    public class Motorcycle : Vehicle, IMotorcycle
    {
        private string category;
        
        public Motorcycle(string make, string model, decimal price, string category) : base(make, model, price)
        {
            this.Category = category;
            this.Type = VehicleType.Motorcycle;
            this.Wheels = 2;
        }

        public string Category
        {
            get
            {
                return this.category;
            }
            private set
            {
                if (!Regex.IsMatch(value, "^[A-Za-z0-9]{3,10}$") || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Category must be between 3 and 10 characters long!");
                }
                this.category = value;
            }
        }

        public override string ToString()
        {
            return $" Motorcycle:" + Environment.NewLine + base.ToString() + Environment.NewLine + $"  Category: {this.Category}";
        }
    }
}
