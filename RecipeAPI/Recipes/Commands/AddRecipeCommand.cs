using MediatR;
using RfCommonLibrary.Recipes.DTOs.QueryDTOs;
using RfCommonLibrary.Utilities;

namespace RecipeAPI.Recipes.Commands
{
    public record AddRecipeCommand(RecipeDTO dto):IRequest<Result<RecipeDTO?>>;
}
