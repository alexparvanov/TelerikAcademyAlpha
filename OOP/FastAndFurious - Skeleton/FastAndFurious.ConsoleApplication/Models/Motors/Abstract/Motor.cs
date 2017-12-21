using System;
using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.Common;

namespace FastAndFurious.ConsoleApplication.Models.Motors.Abstract
{
    public abstract class Motor : IdentifiableObject, IMotor, ITunningPart, IAccelerateable, ITopSpeed, IWeightable, IValuable
    {
        private readonly decimal price;
        private readonly int weight;
        private readonly int acceleration;
        private readonly int topSpeed;
        private readonly int horsepower;
        private readonly TunningGradeType gradeType;
        private readonly CylinderType cylinderType;
        private readonly MotorType engineType;

        public Motor(
            decimal price,
            int weight,
            int acceleration,
            int topSpeed,
            int horsepower,
            TunningGradeType gradeType,
            CylinderType cylinderType,
            MotorType engineType)
        {
            this.price = price;
            this.weight = weight;
            this.acceleration = acceleration;
            this.topSpeed = topSpeed;
            this.horsepower = horsepower;
            this.gradeType = gradeType;
            this.cylinderType = cylinderType;
            this.engineType = engineType;
        }

      public TunningGradeType GradeType
        {
            get { return this.gradeType; }
        }

        public int Acceleration
        {
            get { return this.acceleration; }
        }

        public int TopSpeed
        {
            get { return this.topSpeed; }
        }

        public int Weight
        {
            get { return this.weight; }
        }

        public decimal Price
        {
            get { return this.price; }
        }

        public int Horsepower
        {
            get { return this.horsepower; }
        }

        public MotorType EngineType
        {
            get { return this.engineType; }
        }

        public CylinderType CylinderType
        {
            get { return this.cylinderType; }
        }
    }
}
