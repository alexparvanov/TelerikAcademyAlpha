﻿using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.Tunnings.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Transmissions.Abstract
{
    public class Transmission : TunningPart, ITransmission
    {
        private TransmissionType transmissionType;
        public Transmission(decimal price, int weight, int acceleration, int topSpeed, TunningGradeType gradeType, TransmissionType transmissionType) : base(price, weight, acceleration, topSpeed, gradeType)
        {
            this.transmissionType = transmissionType;
        }

        public TransmissionType TransmissionType { get { return this.transmissionType; } }
    }
}
