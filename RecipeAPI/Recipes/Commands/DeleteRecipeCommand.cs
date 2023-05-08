using MediatR;
using RfCommonLibrary.Recipes.DTOs.QueryDTOs;
using RfCommonLibrary.Utilities;

namespace RecipeAPI.Recipes.Commands
{
    public record DeleteRecipeCommand(Guid id) :IRequest<Result<RecipeDTO?>>;
}
