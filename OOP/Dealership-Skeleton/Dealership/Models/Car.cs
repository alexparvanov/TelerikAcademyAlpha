using System;
using Dealership.Common.Enums;
using Dealership.Contracts;

namespace Dealership.Models
{
    public class Car : Vehicle, ICar
    {
        private int seats;
        
        public Car(string make, string model, decimal price, int seats) : base(make, model, price)
        {
            this.Seats = seats;
            this.Wheels = (int)VehicleType.Car;
            this.Type = VehicleType.Car;
        }

        public int Seats
        {
            get { return this.seats; }
            private set
            {
                if (value < 1 || value > 10)
                {
                    throw new ArgumentException("Seats must be between 1 and 10!");
                }
                this.seats = value;
            }
        }

        public override string ToString()
        {
            return $" Car:" + Environment.NewLine + base.ToString() + Environment.NewLine + $"  Seats: {this.Seats}";
        }
    }
}