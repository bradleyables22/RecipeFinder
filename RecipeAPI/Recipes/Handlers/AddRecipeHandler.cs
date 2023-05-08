using MediatR;
using Microsoft.EntityFrameworkCore;
using RecipeAPI.Data;
using RecipeAPI.Recipes.Commands;
using RfCommonLibrary;
using RfCommonLibrary.Recipes.DatabaseModels;
using RfCommonLibrary.Recipes.DTOs.QueryDTOs;
using RfCommonLibrary.Utilities;

namespace RecipeAPI.Recipes.Handlers
{
    public class AddRecipeHandler : IRequestHandler<AddRecipeCommand, Result<RecipeDTO?>>
    {
        private readonly RecipeContext _context;
        public AddRecipeHandler(RecipeContext context)
        {
            _context = context;
        }
        public async Task<Result<RecipeDTO?>> Handle(AddRecipeCommand request, CancellationToken cancellationToken)
        {
			try
			{
                var entity = new Recipe(request.dto);
                _context.Add(entity);
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                    return new RecipeDTO(entity, true).ToResult();
                else
                    return new Result<RecipeDTO>().Failure("Failed to Add entity.");
			}
			catch (Exception e)
			{
                return new Result<RecipeDTO?>().Failure($"{e.HResult}-{e.Message}");
            }
        }
    }
}
