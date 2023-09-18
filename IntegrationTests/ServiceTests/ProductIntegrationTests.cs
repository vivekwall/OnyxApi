using Microsoft.Extensions.Configuration;
using Onyx.Auth.Service;
using Onyx.Core.Application.Common;
using Onyx.Product.Database;

namespace IntegrationTests.ServiceTests
{
    [TestClass]
    public class ProductIntegrationTests
    {

        [TestMethod]
        public void GetAllProductsTest()
        {
            //Arrange
            var ProductsDb = new ProductsDb();

            //Act
            var products = ProductsDb.GetAllProducts();

            //Assert
            Assert.IsNotNull(products);
        }

        [TestMethod]
        public void GetProductsByColourTest()
        {
            //Arrange
            var ProductsDb = new ProductsDb();

            //Act
            var products = ProductsDb.GetProductsByColor("Blue");

            //Assert
            Assert.IsNotNull(products);
        }

        [TestMethod]
        public void GetProductsByColourWithInvalidTest()
        {
            //Arrange
            var ProductsDb = new ProductsDb();

            //Act
            var products = ProductsDb.GetProductsByColor("XXX");

            //Assert
            Assert.AreEqual(products.Result.Count, 0);
        }
    }
}