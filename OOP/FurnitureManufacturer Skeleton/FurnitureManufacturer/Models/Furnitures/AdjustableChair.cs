using System;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models.Furnitures
{
    public class AdjustableChair : Chair, IAdjustableChair, IFurniture
    {
        public AdjustableChair(string model, MaterialType materialType, decimal price, decimal height, int numbferOfLegs) : base(model, materialType, price, height, numbferOfLegs)
        {
        }

        public void SetHeight(decimal height)
        {
            if (height <= 0)
            {
                throw new ArgumentException("Invalid height!");
            }
            this.Height = height;
        }
    }
}
