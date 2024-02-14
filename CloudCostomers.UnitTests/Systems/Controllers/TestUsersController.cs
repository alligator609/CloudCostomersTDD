using CloudCostomers.API.Controllers;
using CloudCostomers.Domain.Models;
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
        public async Task Get_OnSuccess_InvokeUsersServiceExactlyOnce()
        {
            // Arrange
            var moqUsersService = new Mock<IUserService>();
            moqUsersService.Setup(service => service.GetAllUsers()).ReturnsAsync(new List<User>()
            { 
                new User() {
                    Id = 1,
                    Name = "John Doe",
                    Email = "jhon@mail.com",
                    Address = new Address()
                    {
                        City = "New York",
                        Street = "5th Avenue",
                        ZipCode = "10001"
                    }
                }
            });
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
            moqUsersService.Setup(service => service.GetAllUsers()).ReturnsAsync(new List<User>());
            var sut = new UsersController(moqUsersService.Object);
            // Act
            var result = await sut.Get();
            // Assert
            result.Should().BeOfType<NotFoundResult>();
        }
    }
}