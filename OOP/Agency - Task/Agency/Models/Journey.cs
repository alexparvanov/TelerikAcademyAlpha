using System;
using Agency.Models.Contracts;
using Agency.Models.Vehicles.Contracts;

namespace Agency.Models
{
    public class Journey : IJourney
    {
        private string destination;
        private int distance;
        private string startLocation;
        private IVehicle vehicle;

        public Journey(string startLocation, string destination, int distance, IVehicle vehicle)
        {
            this.StartLocation = startLocation;
            this.Destination = destination;
            this.Distance = distance;
            this.Vehicle = vehicle;
        }

        public string Destination
        {
            get => this.destination;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5 || value.Length > 25)
                {
                    throw new ArgumentException("The Destination's length cannot be less than 5 or more than 25 symbols long.");
                }
                this.destination = value;
            }
        }
        public int Distance
        {
            get => this.distance;
            set
            {
                if (value < 5 || value > 5000)
                {
                    throw new ArgumentException("The Distance cannot be less than 5 or more than 5000 kilometers.");
                }
                this.distance = value;
            }
        }
        public string StartLocation
        {
            get => this.startLocation;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5 || value.Length > 25)
                {
                    throw new ArgumentException("The StartingLocation's length cannot be less than 5 or more than 25 symbols long.");
                }
                this.startLocation = value;
            }
        }
        public IVehicle Vehicle
        {
            get => this.vehicle;
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Null vehicle provided!");
                }
                this.vehicle = value;
            }
        }

        public decimal CalculateTravelCosts()
        {
            decimal travelCosts = this.Distance * this.Vehicle.PricePerKilometer;
            return travelCosts;
        }

        public override string ToString()
        {
            return this.GetType().Name + " ----" + Environment.NewLine +
                        $"Start location: {this.StartLocation}" + Environment.NewLine +
                        $"Destination: {this.Destination}" + Environment.NewLine +
                        $"Distance: {this.Distance}" + Environment.NewLine +
                        $"Vehicle type: {this.Vehicle.Type}" + Environment.NewLine +
                        $"Travel costs: {this.CalculateTravelCosts()}";
        }
    }
}
