using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureManufacturer.Models
{
    public class Company : ICompany
    {
        private readonly string name;
        private readonly string registrationNumber;
        private readonly ICollection<IFurniture> furnitures;

        public Company(string name, string registrationNumber)
        {
            if (string.IsNullOrEmpty(name) || name.Length < 5)
            {
                throw new ArgumentException("Name length must be over 5 chars.");
            }
            this.name = name;

            if (string.IsNullOrEmpty(registrationNumber) || registrationNumber.Any(a => !char.IsDigit(a)) || registrationNumber.Length != 10)
            {
                throw new ArgumentException("Invalid registration number!");
            }
            this.registrationNumber = registrationNumber;
            this.furnitures = new List<IFurniture>();
        }

        public string Name => this.name;

        public string RegistrationNumber => this.registrationNumber;

        public ICollection<IFurniture> Furnitures => this.furnitures;

        public void Add(IFurniture furniture)
        {
            if (furniture == null)
            {
                throw new ArgumentException("Furniture does not exist!");
            }
            this.furnitures.Add(furniture);
        }

        public string Catalog()
        {
            var strBuilder = new StringBuilder();
            strBuilder.Append(String.Format("{0} - {1} - {2} {3}",
                this.Name,
                this.RegistrationNumber,
                this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
                this.Furnitures.Count != 1 ? "furnitures" : "furniture"
            ));

            foreach (var furniture in Furnitures.OrderBy(x => x.Price).ThenBy(x => x.Model))
            {
                strBuilder.Append(Environment.NewLine + furniture);
            }

            return strBuilder.ToString().Trim();
        }

        public IFurniture Find(string model)
        {
            return this.Furnitures.FirstOrDefault(f => f.Model == model);
        }

        public void Remove(IFurniture furniture)
        {
            if (furniture == null)
            {
             //   throw new ArgumentException("Furniture to be removed does not exist!");
                return;
            }

            IFurniture furnitureToBeRemoved = this.furnitures.FirstOrDefault(f => f.Model == furniture.Model);

            if (furnitureToBeRemoved == null)
            {
                //throw new ArgumentException("Furniture to be removed does not exist!");
                return;
            }

            this.furnitures.Remove(furnitureToBeRemoved);
        }
    }
}
