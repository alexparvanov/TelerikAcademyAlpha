using System;
using Agency.Models.Enums;
using Agency.Models.Vehicles.Contracts;

namespace Agency.Models.Vehicles
{
    public class Train : Vehicle, ITrain
    {
        private int carts;
        public Train(int passangerCapacity, decimal pricePerKilometer, int carts) : base(passangerCapacity, pricePerKilometer)
        {
            this.Carts = carts;
            this.Type = VehicleType.Land;
        }
        public override int PassangerCapacity
        {
           protected set
            {
                if (value < 30 || value > 150)
                {
                    throw new ArgumentException("A train cannot have less than 30 passengers or more than 150 passengers.");
                }
                base.PassangerCapacity = value;
            }
        }
        
        public int Carts
        {
            get => this.carts;
            set
            {
                if (value < 1 || value > 15)
                {
                    throw new ArgumentException("A train cannot have less than 1 cart or more than 15 carts.");
                }
                this.carts = value;
            }
        }


        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $"Carts amount: {this.Carts}";
        }
    }
}
