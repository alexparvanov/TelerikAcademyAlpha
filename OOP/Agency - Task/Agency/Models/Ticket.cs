using System;
using Agency.Models.Contracts;

namespace Agency.Models
{
    public class Ticket : ITicket
    {
        private IJourney journey;
        private decimal administrativeCosts;

        public Ticket(IJourney journey, decimal administrativeCosts)
        {
            this.Journey = journey;
            this.AdministrativeCosts = administrativeCosts;
        }

        public decimal AdministrativeCosts
        {
            get => this.administrativeCosts;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Costs cannot be negative!");
                }
                this.administrativeCosts = value;
            }
        }
        public IJourney Journey
        {
            get => this.journey;
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Jorney cannot be null!");
                }
                this.journey = value;
            }
        }
        public decimal CalculatePrice()
        {
            decimal calculatedPrice = this.AdministrativeCosts + this.Journey.CalculateTravelCosts();
            return calculatedPrice;
        }

        public override string ToString()
        {
            return this.GetType().Name + " ----" + Environment.NewLine +
                $"Destination: {this.Journey.Destination}" + Environment.NewLine + 
                $"Price: {this.CalculatePrice()}";
        }
    }
}
