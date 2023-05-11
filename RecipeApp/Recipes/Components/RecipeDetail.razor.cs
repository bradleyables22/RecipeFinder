using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using RfCommonLibrary;
using RfCommonLibrary.Recipes.DTOs.QueryDTOs;

namespace RecipeApp.Recipes.Components
{
    public partial class RecipeDetail
    {
        [Parameter] public string ID { get; set; }
        private RecipeDTO? _recipe { get; set; } = null;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            var result = await _js.InvokeAsync<RecipeDTO>("getRecipe", ID);
            var nullCheck = result.ToResult()
                .Ensure(x => x != null, "NULL");
            if (nullCheck.IsSuccess) 
            {
                
                await _js.InvokeVoidAsync("slideIn", "#detail");
                _recipe = nullCheck.Data;
            }
                

        }

        void GoHome()
        {
            _nav.NavigateTo("/");
        }
    }
}
