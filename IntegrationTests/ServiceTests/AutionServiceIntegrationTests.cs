using Microsoft.Extensions.Configuration;
using Onyx.Auth.Service;
using Onyx.Core.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests.ServiceTests
{
    [TestClass]
    public class AutionServiceIntegrationTests
    {
        [TestMethod]
        public void GetValidTokenTest()
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json", true, true).AddEnvironmentVariables();

            var config = configBuilder.Build();

            var authService = new AuthService(config);

            var userLogin = new UserLogin { Username = "onyxuser", Password = "Password1" };

            var token = authService.GetAuthToken(userLogin);

            Assert.IsNotNull(token);
        }

        [TestMethod]
        public void GetTokenForInvalidUserTest()
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json", true, true).AddEnvironmentVariables();

            var config = configBuilder.Build();

            var authService = new AuthService(config);

            var userLogin = new UserLogin { Username = "onyxuser122", Password = "Password1222" };

            var token = authService.GetAuthToken(userLogin);

            Assert.IsNull(token);
        }
    }
}
