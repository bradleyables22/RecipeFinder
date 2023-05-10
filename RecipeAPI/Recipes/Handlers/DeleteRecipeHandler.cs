using MediatR;
using Microsoft.EntityFrameworkCore;
using RecipeAPI.Data;
using RecipeAPI.Recipes.Commands;
using RfCommonLibrary;
using RfCommonLibrary.Recipes.DTOs.QueryDTOs;
using RfCommonLibrary.Utilities;

namespace RecipeAPI.Recipes.Handlers
{
    public class DeleteRecipeHandler : IRequestHandler<DeleteRecipeCommand, Result<RecipeDTO?>>
    {
        public readonly RecipeContext _context;
        public DeleteRecipeHandler(RecipeContext context)
        {
            _context = context;
        }

        public async Task<Result<RecipeDTO?>> Handle(DeleteRecipeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                try
                {
                    var entity = await _context.Recipes.Where(x=>x.RecipeID == request.id).FirstOrDefaultAsync();
                    if (entity == null)
                        return new Result<RecipeDTO?>().Failure($"Not Found.");

                    _context.Recipes.Remove(entity);
                    await _context.SaveChangesAsync();

                    RecipeDTO? dto = new RecipeDTO(entity, false);

                    return dto.ToResult();
                }
                catch ( DbUpdateException e)
                {
                    return new Result<RecipeDTO?>().Failure($"{e.HResult}-{e.Message}");
                }
               
            }
            catch (Exception e)
            {
                return new Result<RecipeDTO?>().Failure($"{e.HResult}-{e.Message}");
            }
        }
    }
}
