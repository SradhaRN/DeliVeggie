using DeliVeggie.Models.Entity.Product;
using DeliVeggie.RabbitMQ.Abstract;
using DeliVeggie.Services.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace DeliVeggie.Tests
{
    [TestClass]
    public class ProductServiceTest
    {
        private ProductService productService;
        private Mock<IRequester> _mockRequester;

        [TestInitialize]
        public void Initialize()
        {
            this._mockRequester = new Mock<IRequester>();
            this.productService = new ProductService(_mockRequester.Object);
        }

        [TestMethod]
        public void GetProductByIdAsync_WithValidProductId_ReturnsProductDetails()
        {
            //Arrange
            _mockRequester.Setup(x => x.GetProductDetailsRequest(It.IsAny<string>(), It.IsAny<int>()))
                .Returns(GetMockProductDetails());

            //Act
            var result = productService.GetProductDetails("cb4bb750-ee25-4f48-9f3d-80c7dace5bdb");

            //Assert
            Assert.IsTrue(result.Id == "cb4bb750-ee25-4f48-9f3d-80c7dace5bdb");
        }

        #region PRIVATE METHODS

        private Product GetMockProductDetails()
        {
            return new Product
            {
                Id = "cb4bb750-ee25-4f48-9f3d-80c7dace5bdb",
                Name = "Uncle Ben's Rice",
                Price = 15,
                EntryDate = DateTime.Now
            };
        }
        #endregion
    }
}
