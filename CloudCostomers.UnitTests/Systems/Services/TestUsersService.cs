using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudCostomers.Domain.Models;
using CloudCostomers.Domain.Services;
using CloudCostomers.UnitTests.Fixtures;
using CloudCostomers.UnitTests.Helpers;
using FluentAssertions;
using Moq;
using Moq.Protected;

namespace CloudCostomers.UnitTests.Systems.Services
{
    public class TestUsersService
    {
        [Fact]
        public async Task GetAllUsers_WhenCalled_InvokeHttpGetRequest()
        {
            //Arrange
            var expectedResponse = UsersFixture.GetTestUsers();
            var handlerMock = MockHttpMessageHandler<User>.SetupBasicGetResourceList(expectedResponse);
            var httpClient = new HttpClient(handlerMock.Object);

            var sut = new UserService(httpClient);
            // Act
            await sut.GetAllUsers();

            // Assert
            handlerMock
                .Protected()
                .Verify("SendAsync",
                Times.Once(), ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get),
                ItExpr.IsAny<CancellationToken>());

        }

        [Fact]
        public async Task GetAllUsers_WhenCalled_ReturnListofUsersExpextedSize()
        {
            //Arrange
            var expectedResponse = UsersFixture.GetTestUsers();
            var handlerMock = MockHttpMessageHandler<User>.SetupBasicGetResourceList(expectedResponse);
            var httpClient = new HttpClient(handlerMock.Object);

            var sut = new UserService(httpClient);
            // Act
            var result= await sut.GetAllUsers();

            // Assert
            result.Count.Should().Be(expectedResponse.Count);

        }
        [Fact]
        public async Task GetAllUsers_WhenHits404_ReturnEmptyListofUsers()
        {
            //Arrange
            var handlerMock = MockHttpMessageHandler<User>.SetupReturn404();
            var httpClient = new HttpClient(handlerMock.Object);

            var sut = new UserService(httpClient);
            // Act
            var result = await sut.GetAllUsers();

            // Assert
            result.Count.Should().Be(0);

        }

    }
}
