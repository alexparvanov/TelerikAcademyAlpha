﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoService.Core.Contracts;
using AutoService.Core.Validator;
using AutoService.Models.Common.Contracts;

namespace AutoService.Core.Commands
{
    public class RemoveSupplier : ICommand
    {
        private readonly IDatabase database;
        private readonly IValidateCore coreValidator;
        private readonly IWriter writer;
        

        public RemoveSupplier(IDatabase database, IValidateCore coreValidator, IWriter writer)
        {
            this.database = database ?? throw new ArgumentNullException();
            this.coreValidator = coreValidator ?? throw new ArgumentNullException();
            this.writer = writer ?? throw new ArgumentNullException();
        }
        public void ExecuteThisCommand(string[] commandParameters)
        {
            this.coreValidator.ExactParameterLength(commandParameters, 2);

            string supplierUniqueName = commandParameters[1];

            this.coreValidator.CounterpartyNotRegistered(this.database.Suppliers, supplierUniqueName, "supplier");
            this.RemoveCounterparty(supplierUniqueName, this.database.Suppliers);
        }

        private void RemoveCounterparty(string counterpartyUniqueName, IList<ICounterparty> counterparties)
        {
            ICounterparty counterparty = counterparties.FirstOrDefault(x => x.Name == counterpartyUniqueName);
            counterparties.Remove(counterparty);
            this.writer.Write($"{counterpartyUniqueName} removed successfully!");
        }
    }
}
