using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudCostomers.Domain.Models;
using CloudCostomers.Domain.Services;
using CloudCostomers.UnitTests.Fixtures;
using CloudCostomers.UnitTests.Helpers;
using Moq;
using Moq.Protected;

namespace CloudCostomers.UnitTests.Systems.Services
{
    public class TestUsersService
    {
        [Fact]
        public async Task GetAllUsers_WhenCalled_InvokeHttpGetRequest()
        {
            var expectedResponse = UsersFixture.GetTestUsers();
            var handlerMock = MockHttpMessageHandler<User>.SetupBasicGetResourceList(expectedResponse);
            var httpClient = new HttpClient(handlerMock.Object);
            //Arrange
            var sut = new UserService(httpClient);

            // Act
            await sut.GetAllUsers();

            // Assert
            handlerMock.Protected()
                .Verify("SendAsync",
                Times.Once(), ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get),
                ItExpr.IsAny<CancellationToken>());
            // verify HTTP request is invoked 
        }
    }
}
