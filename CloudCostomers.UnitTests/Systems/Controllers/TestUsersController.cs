using CloudCostomers.API.Controllers;
using CloudCostomers.Domain.Models;
using CloudCostomers.Domain.Services;
using CloudCostomers.UnitTests.Fixtures;
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
            var moqUsersService = new Mock<IUserService>();
            moqUsersService.Setup(service => service.GetAllUsers()).ReturnsAsync(UsersFixture.GetTestUsers());
            var sut = new UsersController(moqUsersService.Object);
            // Act
            var result = (OkObjectResult)await sut.Get();

            // Assert
            result.StatusCode.Should().Be(200);

        }

        [Fact]
        public async Task Get_OnSuccess_InvokeUsersServiceExactlyOnce()
        {
            // Arrange
            var moqUsersService = new Mock<IUserService>();
            moqUsersService.Setup(service => service.GetAllUsers()).ReturnsAsync(UsersFixture.GetTestUsers());
            var sut = new UsersController(moqUsersService.Object);
            // Act
            var result = await sut.Get();
            // Assert
            moqUsersService.Verify(
                service => service.GetAllUsers(),
                Times.Once
                );
        }


        [Fact]
        public async Task Get_ONoUsersFoundReturn404()
        {
            // Arrange
            var moqUsersService = new Mock<IUserService>();
            moqUsersService.Setup(service => service.GetAllUsers()).ReturnsAsync(UsersFixture.GetTestUsers());
            var sut = new UsersController(moqUsersService.Object);
            // Act
            var result = await sut.Get();
            // Assert
            result.Should().BeOfType<NotFoundResult>();
        }
    }
}