using Microsoft.AspNetCore.Mvc;
using Moq;
using Onyx.Products.Api.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using MediatR;
using System.Net;

namespace Products.Api.UnitTests
{
    [TestClass]
    public class ProductControllerTests
    {
        [TestMethod]
        public async void GetProducts_AuthorizedUser_ReturnsOk()
        {
            // Arrange
            var expectedResult = HttpStatusCode.OK;
            var mockMediator = new Mock<IMediator>();

            var controller = new ProductController(mockMediator.Object);
            var identity = new ClaimsIdentity(new[]
            {
                   new Claim(ClaimTypes.Name, "testuser"),
                    new Claim(ClaimTypes.Role, "UserRole"),
             }, "TestAuthentication");

            var principal = new ClaimsPrincipal(identity);

            // Set the User property of the HttpContext
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = principal,
                },
            };

            // Act
            var result = await controller.Get();

            // Assert
            var statusCode = (int)((ObjectResult)result).StatusCode;
            Assert.AreEqual((int)expectedResult, statusCode);
        }
    }
}