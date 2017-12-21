using System;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models.Furnitures
{
    // Finish the class
    public class Furniture : IFurniture
    {
        private readonly string model;
        private readonly MaterialType material;
        private readonly decimal price;
        private decimal height;

        public Furniture(string model, MaterialType material, decimal price, decimal height)
        {
            if (string.IsNullOrWhiteSpace(model) || model.Length < 3)
            {
                throw new ArgumentException("Invalid length!");
            }
            this.model = model;
            this.material = material;

            if (price <= 0 || height <= 0)
            {
                throw new ArgumentException("Invalid length!");
            }

            this.price = price;
            this.height = height;
        }

        public string Model => this.model;

        public MaterialType Material => this.material;

        public decimal Price => this.price;

        public decimal Height
        {
            get
            {
                return this.height;
            }
            protected set
            {
                this.height = value;
            }
        }

        public override string ToString()
        {
            return $"Type: {this.GetType().Name}, Model: {this.Model}, Material: {this.Material}, Price: {this.Price}, Height: {this.Height.ToString("0.00")}";
        }
    }
}
