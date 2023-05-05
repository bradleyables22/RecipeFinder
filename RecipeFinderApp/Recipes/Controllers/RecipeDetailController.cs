using RecipeFinderApp.Services;
using RecipeFinderApp.Utilities;
using RestSharp;
using RfCommonLibrary.Recipes.DTOs.QueryDTOs;
using RfCommonLibrary.Utilities;
using RfCommonLibrary;
namespace RecipeFinderApp.Recipes.Controllers
{
    public class RecipeDetailController
    {
        private readonly IClientService _clientService;
        public RecipeDetailController()
        {
            _clientService = new ClientService();
        }

        private Result<RecipeDTO> _recipe = new();

        public async Task<Result<RecipeDTO>> GetRecipeByID(Guid id, bool includeNested = true) 
        {
            RestRequest request = new RestRequest(RecipeAPI.GetRecipe);
            request.AddHeader("recipeID", id);
            request.AddHeader("includeNested", includeNested);
            var result = await _clientService.TryGetAsync<RecipeDTO>(request);

            var nullCheck = result.Ensure(x => x != null, "NULL");

            if (nullCheck.IsFailure)
                return nullCheck.Failure(nullCheck.Message);

            return nullCheck;
        }
    }
}
