using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudCostomers.Domain.Services;

namespace CloudCostomers.UnitTests.Systems.Services
{
    public class TestUsersService
    {
        [Fact]
        public async Task GetAllUsers_WhenCalled_InvokeHttpGetRequest()
        {
            //Arrange
            var sut = new UserService();

            // Act
            var result = await sut.GetAllUsers();
            
            // Assert
        }
    }
}
