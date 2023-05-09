using RecipeApp.Services;
using RecipeApp.Utilities;
using RestSharp;
using RfCommonLibrary.Recipes.DTOs.QueryDTOs;
using RfCommonLibrary;
using Microsoft.JSInterop;
using RfCommonLibrary.Recipes.Enums;

namespace RecipeApp.Recipes.Components
{
    public partial class RecipeList
    {
        public bool _showModal { get; set; } = false;
        private bool _loading = true;
        private List<RecipeDTO> _recipes { get; set; } = new();
        private List<RecipeDTO> _originalRecipes { get; set; } = new();
        public CategoryType selectedCat { get; set; } = CategoryType.Everyone;
        public string searchText { get; set; } = string.Empty;
        private readonly IClientService _clientService;
        public RecipeList()
        {
            _clientService = new ClientService();
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            if (firstRender)
            {
                _originalRecipes = await GetAllRecipesAsync();
                _recipes = _originalRecipes;
                await Task.Delay(TimeSpan.FromSeconds(3)); //to see animation
                _loading = false;
                StateHasChanged();
            }
        }

        async Task<List<RecipeDTO>> GetAllRecipesAsync()
        {
            RestRequest request = new RestRequest(RecipeAPI.AllRecipes);
            List<RecipeDTO> dtos = new();
            var result = await _clientService.TryGetAsync<List<RecipeDTO>>(request);

            if (result.IsFailure)
                return dtos;

            var nullOrEmptyCheck = result
                .Ensure(x => x != null, "Successful, but null")
                .Ensure(x => x.Count != 0, "Successful, but empty");
           
            if (nullOrEmptyCheck.IsFailure)
                return dtos;

            return nullOrEmptyCheck.Data;

        }
        async void NavigateToDetail(Guid id)
        {
            _nav.NavigateTo($"/Recipe/{id}");
        }
        
        void FilterRecipes(string text) 
        {
            if (!string.IsNullOrEmpty(text.Trim()))
            {
                _recipes = _recipes.Where(x => x.Title.ToUpper().Contains(text.ToUpper().Trim())).ToList();
                StateHasChanged();
            }
            else 
            {
                _recipes = _originalRecipes; 
                StateHasChanged();
            }
                
        }
    }
}
