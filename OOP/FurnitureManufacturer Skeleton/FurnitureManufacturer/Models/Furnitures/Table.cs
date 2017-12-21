using System;
using System.Xml.Schema;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models.Furnitures
{
    public class Table : Furniture, ITable, IFurniture
    {
        private readonly decimal length;
        private readonly decimal width;

        public Table(string model, MaterialType materialType, decimal price, decimal height, decimal length, decimal width) : base(model, materialType, price, height)
        {
            this.length = length;
            this.width = width;
        }

        public decimal Length { get { return this.length; } }
        public decimal Width { get { return this.width; } }
        public decimal Area { get {return this.length * this.width; } }

        public override string ToString()
        {
            return base.ToString() + string.Format(", Length: {0}, Width: {1}, Area: {2}", this.Length, this.Width, this.Area);
        }
    }
}
