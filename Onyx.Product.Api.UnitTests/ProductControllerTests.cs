using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using Moq;
using NuGet.Frameworks;
using Onyx.Core.Application.Common;
using Onyx.Products.Api.Controllers;
using System.Net;
using System.Security.Claims;

namespace Onyx.Product.Api.UnitTests
{
    [TestClass]
    public class ProductControllerTests
    {
        [TestMethod]
        public void GetAllProductsTest()
        {
            var expectedResult = HttpStatusCode.OK;
            
            var mockMediator = new Mock<IMediator>();
            var controller = new ProductController(mockMediator.Object);

            mockMediator.Setup(mediator => mediator.Send(It.IsAny<Object>(), default))
              .ReturnsAsync(new List<ProductDto> { new ProductDto {
                    Id = 1,
                    Name = "Test",
                    Color = "Blue"
              } });

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
            var result = controller.Get().Result;

            // Assert
            var statusCode = (int)((ObjectResult)result).StatusCode;
            Assert.AreEqual((int)expectedResult, statusCode);

        }
    }
}