using RecipeFinderApp.Services;
using RfCommonLibrary.Recipes.DTOs.QueryDTOs;
using RestSharp;
using RecipeFinderApp.Utilities;
using RfCommonLibrary;

namespace RecipeFinderApp.Recipes.Components
{
    public partial class RecipeList
    {
        private bool _loading = true;
        private List<RecipeDTO> _recipes { get; set; }
        
        private readonly IClientService _clientService;
        
        public RecipeList()
        {
            _clientService = new ClientService();
            _recipes = new();
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {

            if (firstRender)
            {
                _recipes = await GetAllRecipesAsync();
                _loading = false;
                StateHasChanged();
            }
            
        }

        async Task<List<RecipeDTO>> GetAllRecipesAsync() 
        {
            RestRequest request = new RestRequest(RecipeAPI.AllRecipes);
            var result = await _clientService.TryGetAsync<List<RecipeDTO>>(request);

            if (result.IsFailure)
            {
                Console.WriteLine(result.Message);
                return new List<RecipeDTO> { };
            }

            var nullOrEmptyCheck = result
                .Ensure(x => x != null, "Successful, but null")
                .Ensure(x => x.Count != 0, "Successful, but empty");

            if (nullOrEmptyCheck.IsFailure)
            {
                Console.WriteLine(result.Message);
                return new List<RecipeDTO> { };
            }

            return nullOrEmptyCheck.Data;
        }
    }
}
