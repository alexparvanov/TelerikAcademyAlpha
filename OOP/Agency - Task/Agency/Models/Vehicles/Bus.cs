using System;
using Agency.Models.Enums;
using Agency.Models.Vehicles.Contracts;

namespace Agency.Models.Vehicles
{
    public class Bus : Vehicle, IBus
    {
        public Bus(int passangerCapacity, decimal pricePerKilometer) : base(passangerCapacity, pricePerKilometer)
        {
            this.Type = VehicleType.Land;
        }

        public override int PassangerCapacity
        {
            protected set
            {
                if (value < 10 || value > 50)
                {
                    throw new ArgumentException("A bus cannot have less than 10 passengers or more than 50 passengers.");
                }
                base.PassangerCapacity = value;
            }
        }
    }
}
