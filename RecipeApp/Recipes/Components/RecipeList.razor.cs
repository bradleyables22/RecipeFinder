using RecipeApp.Services;
using RecipeApp.Utilities;
using RestSharp;
using RfCommonLibrary.Recipes.DTOs.QueryDTOs;
using RfCommonLibrary;
using RfCommonLibrary.Recipes.Enums;

namespace RecipeApp.Recipes.Components
{
    public partial class RecipeList
    {
        
        bool _showSettings = false;
        private bool _loading = true;


        public List<RecipeDTO> _recipes { get; set; } = new();
        public List<RecipeDTO> _originalRecipes { get; set; } = new();
        public CategoryType selectedCat { get; set; } = CategoryType.Everyone;
        public string searchText { get; set; } = string.Empty;
        public string divStatus { get; set; } = string.Empty;
        
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            if (firstRender)
            {
                selectedCat = _state.CategoryType;
                if (_state.Recipes != null)
                    _originalRecipes = _state.Recipes;
                else 
                {
                    _originalRecipes = await GetAllRecipesAsync();
                    await Task.Delay(TimeSpan.FromSeconds(3)); //to see animation
                }
                    
                if (selectedCat != CategoryType.Everyone)
                    _recipes = _originalRecipes.Where(x => x.Category == selectedCat).ToList();
                else
                    _recipes = _originalRecipes;
                
                _loading = false;
                StateHasChanged();
            }
            else
            {
                _state.Recipes = _recipes;
                _state.CategoryType = selectedCat;
                if (selectedCat != CategoryType.Everyone)
                    _recipes = _originalRecipes .Where(x => x.Category == selectedCat).ToList();
                else
                    _recipes = _originalRecipes;
            }


        }
        public void ToggleSettings()
        {
            _showSettings = !_showSettings;

            if (_showSettings)
            {
                searchText = string.Empty;
                divStatus = "pointer-events: none;";
            }
            else
                divStatus = string.Empty;
                

            StateHasChanged();
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
                
            }
            StateHasChanged();
        }
    }
}
