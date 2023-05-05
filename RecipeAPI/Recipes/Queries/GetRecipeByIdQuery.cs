using MediatR;
using RfCommonLibrary.Recipes.DTOs.QueryDTOs;
using RfCommonLibrary.Utilities;

namespace RecipeAPI.Recipes.Queries
{
    public record GetRecipeByIdQuery(Guid id, bool includeNested = false) : IRequest<Result<RecipeDTO?>>;
}
