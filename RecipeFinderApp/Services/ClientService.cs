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
    public class ClientService
    {
        private readonly RestClient _client;
        public ClientService()
        {
            _client = new RestClient(RecipeAPI.Base);
        }

        public async Task<Result<T>> TryGetAsync<T>(RestRequest request)
        {
            var response = await _client.ExecuteGetAsync(request);

            if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content))
                return new Result<T> { }.Failure(response.ErrorMessage);

            var parsedObj = JsonConvert.DeserializeObject<T>(response.Content).ToResult();

            var nullCheck = parsedObj.Ensure(x => x != null, "NULL");

            if (nullCheck.IsFailure)
                return nullCheck.Failure(nullCheck.Message);

            else return nullCheck;
        }
    }
}
