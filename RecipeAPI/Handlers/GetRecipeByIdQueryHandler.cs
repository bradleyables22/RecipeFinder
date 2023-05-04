using MediatR;
using Microsoft.EntityFrameworkCore;
using RecipeAPI.Data;
using RecipeAPI.Queries;
using RfCommonLibrary;
using RfCommonLibrary.DTOs.QueryDTOs;
using RfCommonLibrary.Utilities;

namespace RecipeAPI.Handlers
{
    public class GetRecipeByIdQueryHandler : IRequestHandler<GetRecipeByIdQuery, Result<RecipeDTO?>>
    {
        private readonly RecipeContext _recipeContext;

        public GetRecipeByIdQueryHandler(RecipeContext recipeContext)
        {
            _recipeContext = recipeContext;
        }

        public async Task<Result<RecipeDTO?>> Handle(GetRecipeByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _recipeContext.Recipes
                    .Where(x => x.RecipeID == request.id)
                    .Include(x=>x.Ingredients)
                    .Include(x=>x.Instructions)
                    .Select(x=> new RecipeDTO(x,request.includeNested))
                    .FirstOrDefaultAsync();



                return result.ToResult();
            }
            catch (Exception e)
            {
                return new Result<RecipeDTO?>().Failure($"{e.HResult}-{e.Message}");
            }
        }
    }
}
