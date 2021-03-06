﻿using System;
using AutoService.Models.Common;
using AutoService.Models.Common.Contracts;
using AutoService.Models.Common.Enums;

namespace AutoService.Models.Assets
{
    public class BankAccount : Asset
    {
        public event EventHandler CriticalLimitReached;

        private decimal balance;
        private DateTime registrationDate;
        private decimal criticalLimit;

        public BankAccount(string name, IEmployee responsibleEmployee, string uniqueNumber, DateTime registrationDate) : base(name, responsibleEmployee, uniqueNumber)
        {
            this.Balance = 0;
            this.RegistrationDate = registrationDate;
            this.criticalLimit = 300;
        }

        public decimal Balance
        {
            get => this.balance;
            protected set
            {
                this.balance = value;
                if (this.balance <= this.criticalLimit)
                {
                    CriticalLimitReachedEventArgs args = new CriticalLimitReachedEventArgs();
                    args.CriticalLimit = criticalLimit;
                    OnCriticalLimitReached(args);
                }
            }
        }

        public DateTime RegistrationDate
        {
            get => this.registrationDate;
            set { this.registrationDate = value; }
        }

        protected override void ChangeResponsibleEmployee(IEmployee employee)
        {
            if (employee == null)
            {
                throw new ArgumentException("Responsible employee can't be null!");
            }
            if (employee.Responsibilities.Contains(ResponsibilityType.Account) || employee.Responsibilities.Contains(ResponsibilityType.Manage))
            {
                this.ResponsibleEmployee = employee;
            }
            else
            {
                throw new ArgumentException($"Employee cannot be responsible for asset {this.GetType().Name}");
            }
        }

        public void DepositFunds(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount cannot be negative!");
            }
            this.Balance += amount;
        }

        public void WithdrawFunds(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount cannot be negative!");
            }
            if (this.Balance - amount < 0)
            {
                throw new ArgumentException("Remaining amount cannot be negative!");
            }

            this.Balance -= amount;
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine +
                   $"  - Balance: ${this.Balance}";
        }

        public virtual void OnCriticalLimitReached(EventArgs e)
        {
            EventHandler handler = CriticalLimitReached;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
