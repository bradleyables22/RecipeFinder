using Newtonsoft.Json;
using RecipeFinderApp.Utilities;
using RestSharp;
using RfCommonLibrary;
using RfCommonLibrary.Utilities;

namespace RecipeFinderApp.Services
{
    public interface IClientService 
    {
        Task<Result<T>> TryGetAsync<T>(RestRequest request);
    }
    public class ClientService:IClientService
    {
        private readonly RestClient _client;
        public ClientService()
        {
            _client = new RestClient(RecipeAPI.Base);
        }

        public async Task<Result<T>> TryGetAsync<T>(RestRequest request)
        {
            var response = await _client.ExecuteGetAsync(request);

            if (!response.IsSuccessful)
                return new Result<T> { }.Failure(response.ErrorMessage);

            var parsedObj = JsonConvert.DeserializeObject<T>(response.Content).ToResult();

            return parsedObj;
        }
    }
}
