using Newtonsoft.Json;
using RecipeApp.Utilities;
using RestSharp;
using RfCommonLibrary;
using RfCommonLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Services
{
    public interface IClientService
    {
        Task<Result<T>> TryGetAsync<T>(RestRequest request);
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
    }
}
