using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Dealership.Common.Enums;
using Dealership.Contracts;

namespace Dealership.Models
{
    public class Vehicle : IVehicle
    {
        private string make;
        private string model;
        private int wheels;
        private decimal price;
        private VehicleType type;
        private IList<IComment> comments;

        public Vehicle(string make, string model, decimal price)
        {
            this.Make = make;
            this.Model = model;
            this.Price = price;
            this.comments = new List<IComment>();
        }
        public IList<IComment> Comments
        {
            get => this.comments;
        }
        public decimal Price
        {
            get => this.price;
            set
            {
                if (value < 0 || value > 1000000)
                {
                    throw new ArgumentException("Price must be between 0.0 and 1000000.0!");
                }
                this.price = value;
                ;
            }
        }
        public int Wheels { get { return this.wheels; } protected set { this.wheels = value; } }
        public VehicleType Type { get { return this.type; } protected set { this.type = value; } }
        public string Make
        {
            get => this.make;

            private set
            {
                if (value == null || value.Length < 2 || value.Length > 15)
                { throw new ArgumentException("Make must be between 2 and 15 characters long!"); }
                this.make = value;
            }
        }
        public string Model
        {
            get => this.model;

            private set
            {
                if (value == null || value.Length < 1 || value.Length > 15)
                { throw new ArgumentException("Model must be between 1 and 15 characters long!"); }
                this.model = value;
            }
        }

        public override string ToString()
        {
            return $"  Make: {this.Make}" + Environment.NewLine +
                $"  Model: {this.Model}" + Environment.NewLine +
                $"  Wheels: {this.Wheels}" + Environment.NewLine +
                $"  Price: ${this.Price}";
        }
    }
}
