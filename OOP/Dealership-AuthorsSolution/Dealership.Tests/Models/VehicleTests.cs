using Dealership.Contracts;
using Dealership.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Reflection;

namespace Dealership.Tests.Models
{
    [TestClass]
    public class VehicleTests
    {
        [TestMethod]
        public void Vehicle_Type_ShouldImplementIVehicleInterface()
        {
            var type = typeof(Vehicle);
            var isAssignable = typeof(IVehicle).IsAssignableFrom(type);

            Assert.IsTrue(isAssignable, "Vehicle class does not implement IVehicle interface!");
        }

        [TestMethod]
        public void Vehicle_Type_ShouldBeAbstract()
        {
            var type = typeof(Vehicle);
            Assert.IsTrue(type.IsAbstract, "Vehicle class is not abstract!");
        }

        [TestMethod]
        public void Vehicle_Type_ShouldHavePrivateMakeField()
        {
            var type = typeof(Vehicle);

            FieldInfo[] fields = type.GetFields(
                         BindingFlags.NonPublic |
                         BindingFlags.Instance);

            Assert.IsTrue(fields.Any(x => x.Name == "make") || fields.Any(x => x.Name == "_make"), "Vehicle does not contain private field 'make'!");
        }

        [TestMethod]
        public void Vehicle_Type_ShouldHavePrivateModelField()
        {
            var type = typeof(Vehicle);

            FieldInfo[] fields = type.GetFields(
                         BindingFlags.NonPublic |
                         BindingFlags.Instance);

            Assert.IsTrue(fields.Any(x => x.Name == "model") || fields.Any(x => x.Name == "_model"), "Vehicle does not contain private field 'model'!");
        }

        [TestMethod]
        public void Vehicle_Type_ShouldHavePrivatePriceField()
        {
            var type = typeof(Vehicle);

            FieldInfo[] fields = type.GetFields(
                         BindingFlags.NonPublic |
                         BindingFlags.Instance);

            Assert.IsTrue(fields.Any(x => x.Name == "price") || fields.Any(x => x.Name == "_price"), "Vehicle does not contain private field 'price'!");
        }
    }
}
