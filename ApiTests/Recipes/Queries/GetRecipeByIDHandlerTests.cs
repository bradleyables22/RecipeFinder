using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using RecipeAPI.Data;
using RecipeAPI.Recipes.Handlers;
using RecipeAPI.Recipes.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTests.Recipes.Queries
{
    public class GetRecipeByIDHandlerTests
    {
        [Fact]
        public async Task GetRecipeByIDHandlerTest_WithNested_Expected()
        {
            var recipes = Helpers.GetRecipes();

            var contextMock = new Mock<RecipeContext>(MockBehavior.Default, new DbContextOptions<RecipeContext>());
            contextMock.Setup(x => x.Recipes)
                .ReturnsDbSet(recipes);

            var query = new GetRecipeByIdQuery(Guid.Parse("00000000-0000-0000-0000-000000000001"), true);

            var handler = new GetRecipeByIdQueryHandler(contextMock.Object);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result.Data);
            Assert.True(result.IsSuccess);
            Assert.NotEmpty(result.Data.Ingredients);
            Assert.NotEmpty(result.Data.Instructions);
            
        }

        [Fact]
        public async Task GetRecipeByIDHandlerTest_Expected()
        {
            var recipes = Helpers.GetRecipes();

            var contextMock = new Mock<RecipeContext>(MockBehavior.Default, new DbContextOptions<RecipeContext>());
            contextMock.Setup(x => x.Recipes)
                .ReturnsDbSet(recipes);

            var query = new GetRecipeByIdQuery(Guid.Parse("00000000-0000-0000-0000-000000000001"));

            var handler = new GetRecipeByIdQueryHandler(contextMock.Object);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result.Data);
            Assert.True(result.IsSuccess);
            Assert.Null(result.Data.Ingredients);
            Assert.Null(result.Data.Instructions);
        }
    }
}
