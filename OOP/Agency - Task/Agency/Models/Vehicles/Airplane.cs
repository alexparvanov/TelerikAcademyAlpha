using System;
using Agency.Models.Enums;
using Agency.Models.Vehicles.Contracts;

namespace Agency.Models.Vehicles
{
    public class Airplane : Vehicle, IAirplane
    {
        private bool hasFreeFood;

        public Airplane(int passangerCapacity, decimal pricePerKilometer, bool hasFreeFood) : base(passangerCapacity, pricePerKilometer)
        {
            this.HasFreeFood = hasFreeFood;
            this.Type = VehicleType.Air;
        }

        public bool HasFreeFood
        {
            get => this.hasFreeFood;
            set { this.hasFreeFood = value; }
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $"Has free food: {this.HasFreeFood}";
        }
    }
}
