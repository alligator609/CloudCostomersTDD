using System.Net.Http.Json;
using CloudCostomers.Domain.Config;
using CloudCostomers.Domain.Models;
using Microsoft.Extensions.Options;

namespace CloudCostomers.Domain.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
    }
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly UserConfigOptions _apiConfig;
        public UserService(HttpClient httpClient,
            IOptions<UserConfigOptions> apiconfig)
        {
            _httpClient = httpClient;
            _apiConfig = apiconfig.Value;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var response = await _httpClient.GetAsync(_apiConfig.Endpoint);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new List<User>();
            }
            var responseContent = response.Content;
            var allUsers = await responseContent.ReadFromJsonAsync<List<User>>();
            return allUsers.ToList();
            
        }
    }
}
