using System;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models.Furnitures
{
    public class ConvertibleChair : Chair, IConvertibleChair, IFurniture
    {
        private readonly decimal originalHeight;

        public ConvertibleChair(string model, MaterialType materialType, decimal price, decimal height, int numberOfLegs) : base(model, materialType, price, height, numberOfLegs)
         {
           this.originalHeight = height;
        }

        public bool IsConverted { get; private set;}

        public void Convert()
        {
            this.IsConverted = !this.IsConverted;

            if (this.IsConverted == true)
            {
                this.Height = 0.10m;
            }
            else
            {
                this.Height = this.originalHeight;
            }
        }

        public override string ToString()
        {
            return base.ToString() + String.Format(", State: {0}", IsConverted == true ? "Converted" : "Normal");
        }
    }
}
