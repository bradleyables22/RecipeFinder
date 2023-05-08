using Microsoft.AspNetCore.Components;
using RfCommonLibrary.Recipes.DTOs.QueryDTOs;

namespace RecipeApp.Recipes.Components
{
    public partial class RecipeOverview
    {
        [Parameter] public RecipeDTO Recipe { get; set; } = new();

    }
}
