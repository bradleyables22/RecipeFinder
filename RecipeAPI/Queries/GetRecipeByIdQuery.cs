using MediatR;
using RfCommonLibrary.DTOs.QueryDTOs;
using RfCommonLibrary.Utilities;

namespace RecipeAPI.Queries
{
    public record GetRecipeByIdQuery(Guid id,bool includeNested = false) :IRequest<Result<RecipeDTO?>>;
}
