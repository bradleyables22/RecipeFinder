using MediatR;
using RfCommonLibrary.DTOs.QueryDTOs;
using RfCommonLibrary.Utilities;

namespace RecipeAPI.Queries
{
    public record GetAllRecipesQuery(bool includeNested = false) : IRequest<Result<List<RecipeDTO>>>;
}
