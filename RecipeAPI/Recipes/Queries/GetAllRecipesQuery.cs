using MediatR;
using RfCommonLibrary.Recipes.DTOs.QueryDTOs;
using RfCommonLibrary.Utilities;

namespace RecipeAPI.Recipes.Queries
{
    public record GetAllRecipesQuery(bool includeNested = false) : IRequest<Result<List<RecipeDTO>>>;
}
