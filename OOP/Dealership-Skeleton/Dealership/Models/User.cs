using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Dealership.Common.Enums;
using Dealership.Contracts;

namespace Dealership.Models
{
    public class User : IUser
    {
        private string username;
        private string firstName;
        private string lastName;
        private string password;
        //private Role role;
        private IList<IVehicle> vehicles;

        public User(string username, string firstName, string lastName, string password, Role role)
        {
            this.Username = username;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
            this.Role = role;
            vehicles = new List<IVehicle>();
        }

        public string Username
        {
            get { return this.username; }
            set
            {
                if (value.Length < 2 || value.Length > 20)
                {
                    throw new ArgumentException("Username must be between 2 and 20 characters long!");
                }

                if (!Regex.IsMatch(value, "^[A-Za-z0-9]+$"))
                {
                    throw new ArgumentException("Username contains invalid symbols!");
                }
                this.username = value;
            }
        }

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (!Regex.IsMatch(value, "^[A-Za-z]{2,20}$"))
                {
                    throw new ArgumentException("Firstname must be between 2 and 20 characters long!");
                }
                this.firstName = value;
            }
        }
        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (!Regex.IsMatch(value, "^[A-Za-z]{2,20}$"))
                {
                    throw new ArgumentException("Lastname must be between 2 and 20 characters long!");
                }
                this.lastName = value;
            }
        }
        public string Password
        {
            get { return this.password; }
            set
            {
                if (!Regex.IsMatch(value, "^[A-Za-z0-9@*_-]{5,30}$"))
                {
                    throw new ArgumentException("Password must be between 5 and 30 characters long!");
                }
                this.password = value;
            }
        }
        public Role Role { get; }
        public IList<IVehicle> Vehicles { get { return this.vehicles; } }


        public void AddVehicle(IVehicle vehicle)
        {
            if (vehicle == null)
            {
                throw new ArgumentNullException("Invalid vehicle input to add method!");
            }
            if (this.Role == Role.Admin)
            {
                throw new InvalidOperationException("You are an admin and therefore cannot add vehicles!");
            }
            if (this.Role != Role.VIP && this.Vehicles.Count == 5)
            {
                throw new InvalidOperationException("You are not VIP and cannot add more than 5 vehicles!");
            }
            this.Vehicles.Add(vehicle);
        }

        public void RemoveVehicle(IVehicle vehicle)
        {
            if (vehicle == null)
            {
                throw new ArgumentNullException("Invalid vehicle input to remove method!");
            }
            this.Vehicles.Remove(vehicle);
        }

        public void AddComment(IComment commentToAdd, IVehicle vehicleToAddComment)
        {
            if (commentToAdd == null || vehicleToAddComment == null)
            {
                throw new ArgumentNullException("Invalid comment or vehicle input to add comment method!");
            }

            vehicleToAddComment.Comments.Add(commentToAdd);
        }

        public void RemoveComment(IComment commentToRemove, IVehicle vehicleToRemoveComment)
        {
            if (commentToRemove == null || vehicleToRemoveComment == null)
            {
                throw new ArgumentNullException("Invalid comment or vehicle input to remove comment method!");
            }

            if (this.Username != commentToRemove.Author)
            {
                throw new ArgumentException("You are not the author!");
            }

            vehicleToRemoveComment.Comments.Remove(commentToRemove);
        }

        public string PrintVehicles()
        {
            var sb = new StringBuilder();
            sb.Append($"--USER {this.Username}--" + Environment.NewLine);

            if (this.vehicles.Count == 0)
            {
                sb.Append("--NO VEHICLES--");
            }
            else
            {
                int counter = 1;
                foreach (var vehicle in vehicles)
                {
                    sb.Append($"{counter}.");
                    counter++;

                    sb.Append(vehicle + Environment.NewLine);

                    if (vehicle.Comments.Count == 0)
                    {
                        sb.Append("    --NO COMMENTS--" + Environment.NewLine);
                    }
                    else
                    {
                        sb.Append("    --COMMENTS--" + Environment.NewLine);

                        foreach (var comment in vehicle.Comments)
                        {
                            sb.Append(comment + Environment.NewLine);
                        }
                        sb.Append("    --COMMENTS--" + Environment.NewLine);

                    }
                }
            }
            return sb.ToString().Trim();
        }

        public override string ToString()
        {
            return $"Username: {this.Username}, FullName: {this.FirstName} {this.LastName}, Role: {this.Role}";
        }
    }
}
