using CloudCostomers.Domain.Models;

namespace CloudCostomers.UnitTests.Fixtures
{
    public static class UsersFixture
    {
        public static List<User> GetTestUsers() => new()
        {
            new User {
                Id = 1,
                Name = "John Doe",
                Email = "jhon@mail.com",
                Address = new Address()
                {
                    City = "New York",
                    Street = "5th Avenue",
                    ZipCode = "10001"
                }
            },
            new User {
                Id = 1,
                Name = "John Doe",
                Email = "jhon@mail.com",
                Address = new Address()
                {
                    City = "New York",
                    Street = "5th Avenue",
                    ZipCode = "10001"
                }
            },
            new User {
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
        };
    }

}
