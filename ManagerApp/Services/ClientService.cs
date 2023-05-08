using ManagerApp.Utilities;
using Newtonsoft.Json;
using RestSharp;
using RfCommonLibrary;
using RfCommonLibrary.Utilities;

namespace ManagerApp.Services
{
    public interface IClientService
    {
        Task<Result<T>> TryGetAsync<T>(RestRequest request);
        Task<Result<T>> TryPostAsync<T>(RestRequest request);
        Task<Result<T>> TryPutAsync<T>(RestRequest request);
        /// <summary>
        /// Must send Method.Delete in request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Result<T>> TryDeleteAsync<T>(RestRequest request);

    }
    public class ClientService : IClientService
    {
        private readonly RestClient _client;
        public ClientService()
        {
            _client = new RestClient(RecipeAPI.Base);
        }

        public async Task<Result<T>> TryGetAsync<T>(RestRequest request)
        {
            try
            {
                var response = await _client.ExecuteGetAsync(request);

                if (!response.IsSuccessful)
                    return new Result<T> { }.Failure(response.ErrorMessage);

                var parsedObj = JsonConvert.DeserializeObject<T>(response.Content);

                return parsedObj.ToResult();
            }
            catch (Exception e)
            {
                return new Result<T> { }.Failure($"{e.Message}");
            }

        }
        public async Task<Result<T>> TryPostAsync<T>(RestRequest request)
        {
            try
            {
                var response = await _client.ExecutePostAsync(request);

                if (!response.IsSuccessful)
                    return new Result<T> { }.Failure(response.ErrorMessage);

                var parsedObj = JsonConvert.DeserializeObject<T>(response.Content);

                return parsedObj.ToResult();
            }
            catch (Exception e)
            {
                return new Result<T> { }.Failure($"{e.Message}");
            }
        }
        public async Task<Result<T>> TryPutAsync<T>(RestRequest request)
        {
            try
            {
                var response = await _client.ExecutePostAsync(request);

                if (!response.IsSuccessful)
                    return new Result<T> { }.Failure(response.ErrorMessage);

                var parsedObj = JsonConvert.DeserializeObject<T>(response.Content);

                return parsedObj.ToResult();
            }
            catch (Exception e)
            {
                return new Result<T> { }.Failure($"{e.Message}");
            }
        }
        public async Task<Result<T>> TryDeleteAsync<T>(RestRequest request)
        {
            try
            {
                var response = await _client.ExecuteAsync(request);

                if (!response.IsSuccessful)
                    return new Result<T> { }.Failure(response.ErrorMessage);

                var parsedObj = JsonConvert.DeserializeObject<T>(response.Content);

                return parsedObj.ToResult();
            }
            catch (Exception e)
            {
                return new Result<T> { }.Failure($"{e.Message}");
            }
        }
    }
}
