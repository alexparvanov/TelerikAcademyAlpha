using System;
using System.Collections.Generic;
using System.Linq;
using FastAndFurious.ConsoleApplication.Common.Constants;
using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Common.Utils;
using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.Common;

namespace FastAndFurious.ConsoleApplication.Models.Drivers.Abstract
{
    public abstract class Driver : IdentifiableObject, IDriver
    {
        private readonly string name;
        private readonly GenderType gender;
        private readonly ICollection<IMotorVehicle> vehicles;
        private IMotorVehicle activeVehicle;

        public Driver(string name, GenderType gender) : base()
        {
            this.name = name;
            this.gender = gender;
            this.vehicles = new List<IMotorVehicle>();
        }

        public IMotorVehicle ActiveVehicle
        {
            get { return this.activeVehicle; }
        }

        public GenderType Gender
        {
            get { return this.gender; }
        }

        public string Name
        {
            get { return this.name; }
        }

        public IEnumerable<IMotorVehicle> Vehicles
        {
            get { return this.vehicles; }
        }

        public void AddVehicle(IMotorVehicle vehicle)
        {
            if (this.Vehicles.Any(x => x.Id == vehicle.Id))
            {
                throw new ArgumentException(GlobalConstants.DriverCannotBeAssignedAsOwnerToVehicleMoreThanOnceExceptionMessage);
            }

            this.vehicles.Add(vehicle);
        }

        public bool RemoveVehicle(IMotorVehicle vehicle)
        {
            return this.vehicles.Remove(vehicle);
        }

        public void SetActiveVehicle(IMotorVehicle vehicle)
        {
            if (vehicle == null)
            {
                throw new ArgumentNullException(GlobalConstants.CannotSetNullObjectAsActiveVehicleExceptionMessage);
            }

            if (!this.Vehicles.Any(x => x.Id == vehicle.Id))
            {
                throw new InvalidOperationException(GlobalConstants.CannotSetForeignVehicleAsActiveExceptionMessage);
            }

            this.activeVehicle = vehicle;
        }
    }
}
