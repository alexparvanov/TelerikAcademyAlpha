using System;
using System.Collections.Generic;
using Agency.Commands.Contracts;
using Agency.Core.Contracts;
using Agency.Models.Contracts;

namespace Agency.Commands.Creating
{
    public class CreateTicketCommand : ICommand
    {
        private readonly IAgencyFactory factory;
        private readonly IEngine engine;

        public CreateTicketCommand(IAgencyFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public string Execute(IList<string> parameters)
        {
            int journeyID;
            decimal administrationCosts;
            IJourney jorney;


            try
            {
                journeyID = int.Parse(parameters[0]);
                administrationCosts =  decimal.Parse(parameters[1]);
                jorney = this.engine.Journeys[journeyID];
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateTicket command parameters.");
            }

           var ticket = this.factory.CreateTicket(jorney, administrationCosts);
            this.engine.Tickets.Add(ticket);

            return $"Ticket with ID {engine.Tickets.Count - 1} was created.";
        }
    }
}
