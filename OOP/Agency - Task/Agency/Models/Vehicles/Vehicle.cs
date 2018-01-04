using System;
using Agency.Models.Enums;
using Agency.Models.Vehicles.Contracts;

namespace Agency.Models.Vehicles
{
    public class Vehicle : IVehicle
    {
        private int passangerCapacity;
        private decimal pricePerKilometer;
        private VehicleType type;

        protected Vehicle(int passangerCapacity, decimal pricePerKilometer)
        {
            this.PassangerCapacity = passangerCapacity;
            this.PricePerKilometer = pricePerKilometer;
        }

        public virtual int PassangerCapacity
        {
            get => this.passangerCapacity;
            protected set
            {
                if (value < 1 || value > 800)
                {
                    throw new ArgumentException("A vehicle with less than 1 passengers or more than 800 passengers cannot exist!");
                }
                this.passangerCapacity = value;
            }
        }

        public virtual decimal PricePerKilometer
        {
            get => this.pricePerKilometer;
            protected set
            {
                if (value < 0.10m || value > 2.50m)
                {
                    throw new ArgumentException("A vehicle with a price per kilometer lower than $0.10 or higher than $2.50 cannot exist!");
                }
                this.pricePerKilometer = value;
            }
        }

        public VehicleType Type { get; protected set; }

        public override string ToString()
        {
            return this.GetType().Name + " ----" + Environment.NewLine
                   + $"Passenger capacity: {this.PassangerCapacity}" + Environment.NewLine
                   + $"Price per kilometer: {this.PricePerKilometer}" + Environment.NewLine
                   + $"Vehicle type: {this.Type}";
        }
    }
}
