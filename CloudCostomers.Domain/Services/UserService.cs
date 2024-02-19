using CloudCostomers.Domain.Models;

namespace CloudCostomers.Domain.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
    }
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/users");
            response.EnsureSuccessStatusCode();
            var users = new List<User>();
            return users;
        }
    }
}
