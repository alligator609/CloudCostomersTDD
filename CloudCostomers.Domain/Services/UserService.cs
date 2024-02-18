using CloudCostomers.Domain.Models;

namespace CloudCostomers.Domain.Services
{
    public interface IUserService
    {
        public Task<List<User>> GetAllUsers();
    }
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        Task<List<User>> IUserService.GetAllUsers()
        {
            throw new NotImplementedException();
        }
    }
}
