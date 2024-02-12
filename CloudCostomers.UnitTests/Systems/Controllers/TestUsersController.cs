using CloudCostomers.API.Controllers;
using CloudCostomers.Domain.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CloudCostomers.UnitTests.Systems.Controllers
{
    public class TestUsersController
    {
        [Fact]
        public async Task Get_OnSuccess_ReturnStatusCode200()
        {
            // Arrange
            var moqUserService = new Mock<IUserService>();
            var sut = new UsersController(moqUserService.Object);
            // Act
            var result = (OkObjectResult)await sut.Get();

            // Assert
            result.StatusCode.Should().Be(200);

        }

        [Fact]
        public async Task Get_OnSuccess_InvokeUsersService()
        {
            // Arrange
            var moqUserService = new Mock<IUserService>();
            var sut = new UsersController( moqUserService.Object);
            // Act
            var result = (OkObjectResult)await sut.Get();

            // Assert
        }


    }
}