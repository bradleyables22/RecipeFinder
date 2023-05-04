using MediatR;
using Microsoft.EntityFrameworkCore;
using RecipeAPI.Data;
using RecipeAPI.Queries;
using RfCommonLibrary;
using RfCommonLibrary.DTOs.QueryDTOs;
using RfCommonLibrary.Utilities;

namespace RecipeAPI.Handlers
{
    public class GetAllRecipesHandler : IRequestHandler<GetAllRecipesQuery, Result<List<RecipeDTO>>>
    {
        private readonly RecipeContext _context;
        public GetAllRecipesHandler(RecipeContext context)
        {
            _context = context;
        }

        public async Task<Result<List<RecipeDTO>>> Handle(GetAllRecipesQuery request, CancellationToken cancellationToken)
        {
			try
			{
                var result = await _context.Recipes
                    .Include(x=>x.Ingredients)
                    .Include(x=>x.Instructions)
                    .OrderByDescending(x => x.PublishedAt)
                    .Select(x=> new RecipeDTO(x, request.includeNested))
                    .ToListAsync()
                    ;

                return result.ToResult();

			}
			catch (Exception e)
			{
				return new Result<List<RecipeDTO>>().Failure($"{e.HResult}-{e.Message}");
			}
        }
    }
}
