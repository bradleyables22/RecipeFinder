using MediatR;
using RecipeAPI.Data;
using RecipeAPI.Recipes.Commands;
using RfCommonLibrary;
using RfCommonLibrary.Recipes.DatabaseModels;
using RfCommonLibrary.Recipes.DTOs.QueryDTOs;
using RfCommonLibrary.Utilities;

namespace RecipeAPI.Recipes.Handlers
{
    public class UpdateRecipeHandler : IRequestHandler<UpdateRecipeCommand, Result<RecipeDTO?>>
    {
        private readonly RecipeContext _context;
        public UpdateRecipeHandler(RecipeContext con)
        {
            _context = con;
        }

        public async Task<Result<RecipeDTO?>> Handle(UpdateRecipeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = new Recipe(request.dto);
                _context.Update(entity);
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                    return new RecipeDTO(entity, true).ToResult();
                else
                    return new Result<RecipeDTO>().Failure("Failed to update entity.");
            }
            catch (Exception e)
            {
                return new Result<RecipeDTO?>().Failure($"{e.HResult}-{e.Message}");
            }
        }
    }
}
