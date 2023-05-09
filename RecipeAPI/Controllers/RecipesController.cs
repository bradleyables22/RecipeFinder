using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecipeAPI.Recipes.Commands;
using RecipeAPI.Recipes.Queries;
using RfCommonLibrary;
using RfCommonLibrary.Recipes.DTOs.QueryDTOs;

namespace RecipeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RecipesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get All Recipes, this does not include nested objects
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<RecipeDTO>>> GetAllRecipes()
        {
            var result = await _mediator.Send(new GetAllRecipesQuery());
            if (result.IsFailure)
                return BadRequest(result.Message);

            var emptyCheck = result
                .Ensure(x=>x.Count() != 0, "No Data")
                ;

            if (emptyCheck.IsFailure)
                return NoContent();
            else
                return Ok(result.Data);
        }
        /// <summary>
        /// Get a Recipe
        /// </summary>
        /// <returns></returns>
        [HttpGet("Get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RecipeDTO>> GetRecipeByID([FromHeader] Guid recipeID, [FromHeader] bool? includeNested = null)
        {
            var result = await _mediator.Send(new GetRecipeByIdQuery(recipeID, Convert.ToBoolean(includeNested)));
            if (result.IsFailure)
                return BadRequest(result.Message);

            var nullCheck = result
                .Ensure(x => x != null, "No Data")
                ;

            if (nullCheck.IsFailure)
                return NoContent();
            else
                return Ok(result.Data);
        }
        /// <summary>
        /// Add a recipe and its nested items.
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RecipeDTO>> Create(RecipeDTO recipe) 
        {
            var result = await _mediator.Send(new AddRecipeCommand(recipe));

            if (result.IsFailure)
                return BadRequest(result.Message);
            else
                return Ok(result.Data);
        }
        /// <summary>
        /// Update a recipe and it's nested items.
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns></returns>
        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RecipeDTO>> Update(RecipeDTO recipe)
        {
            var result = await _mediator.Send(new UpdateRecipeCommand(recipe));

            if (result.IsFailure)
                return BadRequest(result.Message);
            else
                return Ok(result.Data);
        }

        /// <summary>
        /// Delete a given Recipe.
        /// </summary>
        /// <param name="recipeID"></param>
        /// <returns></returns>
        [HttpDelete("Delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RecipeDTO>> Delete([FromHeader] string recipeID) 
        {
            var result = await _mediator.Send(new DeleteRecipeCommand(Guid.Parse(recipeID)));
            if (result.IsFailure)
                return BadRequest(result.Message);
            else
                return Ok(result.Data);
        } 
    }
}
