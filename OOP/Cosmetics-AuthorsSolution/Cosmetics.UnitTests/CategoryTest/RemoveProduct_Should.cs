using Cosmetics.Common;
using Cosmetics.Contracts;
using Cosmetics.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Cosmetics.UnitTests.CategoryTest
{
    [TestClass]
    public class RemoveProduct_Should
    {
        [TestMethod]
        public void ThrowWhenTheProductIsNull()
        {
            // Arrange, Act
            var category = new Category("test");

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => category.RemoveProduct(null));
        }

        [TestMethod]
        public void RemoveProductWhenProductIsValid()
        {
            // Arrange, Act
            var category = new Category("name");
            var productToAdd = new Mock<IProduct>();

            category.Products.Add(productToAdd.Object);
            category.Products.Add(productToAdd.Object);

            // Act
            category.RemoveProduct(productToAdd.Object);

            //Assert
            Assert.AreEqual(1, category.Products.Count);
        }

        [TestMethod]
        public void ThrowWhenProductNotFound()
        {
            // Arrange, Act
            var category = new Category("name");
            var productToAdd = new Mock<IProduct>();

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => category.RemoveProduct(productToAdd.Object));
        }
    }
}
