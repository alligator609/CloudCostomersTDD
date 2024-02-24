using CloudCostomers.Domain.Config;
using CloudCostomers.Domain.Models;
using CloudCostomers.Domain.Services;
using CloudCostomers.UnitTests.Fixtures;
using CloudCostomers.UnitTests.Helpers;
using FluentAssertions;
using Microsoft.Extensions.Options;
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
            var config = Options.Create(
             new UserConfigOptions
             {
                 Endpoint = "http://test.com/users"
             });

            var sut = new UserService(httpClient, config);
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

            var config = Options.Create(
                new UserConfigOptions
                {
                    Endpoint = "http://test.com/users"
                });

            var sut = new UserService(httpClient, config);
            // Act
            var result = await sut.GetAllUsers();

            // Assert
            result.Count.Should().Be(expectedResponse.Count);

        }
        [Fact]
        public async Task GetAllUsers_WhenHits404_ReturnEmptyListofUsers()
        {
            //Arrange
            var config = Options.Create(
             new UserConfigOptions
             {
                 Endpoint = "http://test.com/users"
             });
            var handlerMock = MockHttpMessageHandler<User>.SetupReturn404();
            var httpClient = new HttpClient(handlerMock.Object);

            var sut = new UserService(httpClient, config);
            // Act
            var result = await sut.GetAllUsers();

            // Assert
            result.Count.Should().Be(0);

        }

        [Fact]
        public async Task GetAllUsers_WhenCalled_InvokesConfiguredExternalUrl()
        {
            //Arrange
            var endpoint = "http://test.com/users";
            var config = Options.Create(
             new UserConfigOptions
             {
                 Endpoint = endpoint
             });
            var expectedResponse = UsersFixture.GetTestUsers();
            var handlerMock = MockHttpMessageHandler<User>.SetupBasicGetResourceList(expectedResponse, endpoint);
            var httpClient = new HttpClient(handlerMock.Object);

            var sut = new UserService(httpClient, config);
            // Act
            var result = await sut.GetAllUsers();

            // Assert
            handlerMock
                   .Protected()
                   .Verify("SendAsync",
                   Times.Once(),
                   ItExpr.Is<HttpRequestMessage>(req =>
                   req.Method == HttpMethod.Get && req.RequestUri.ToString() == endpoint
                   ),
                   ItExpr.IsAny<CancellationToken>());

        }
    }
}
