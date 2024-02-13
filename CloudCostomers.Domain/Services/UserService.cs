using CloudCostomers.Domain.Models;

namespace CloudCostomers.Domain.Services
{
    public interface IUserService
    {
        public Task<List<User>> GetAllUsers();
    }
    public class UserService : IUserService
    {
        public UserService()
        {
        }

        Task<List<User>> IUserService.GetAllUsers()
        {
            throw new NotImplementedException();
        }
    }
}
