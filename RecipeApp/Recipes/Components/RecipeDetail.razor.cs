using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using RfCommonLibrary;
using RfCommonLibrary.Recipes.DTOs.QueryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                _recipe = nullCheck.Data;
        }

        void GoHome()
        {
            _nav.NavigateTo("/");
        }
    }
}
