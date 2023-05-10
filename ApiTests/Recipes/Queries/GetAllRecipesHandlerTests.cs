using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using RecipeAPI.Data;
using RecipeAPI.Recipes.Handlers;
using RecipeAPI.Recipes.Queries;

namespace ApiTests.Recipes.Queries
{
    public class GetAllRecipesHandlerTests
    {
        [Fact]
        public async Task GetAllRecipesHandlerTest_Expected()
        {
            var recipes = Helpers.GetRecipes();

            var contextMock = new Mock<RecipeContext>(MockBehavior.Default, new DbContextOptions<RecipeContext>());
            contextMock.Setup(x => x.Recipes)
                .ReturnsDbSet(recipes);

            var query = new GetAllRecipesQuery();

            var handler = new GetAllRecipesHandler(contextMock.Object);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result.Data);
            Assert.NotEmpty(result.Data);
            Assert.True(result.IsSuccess);
            Assert.True(result.Data.Count() == 3);
        }

        [Fact]
        public async Task GetAllRecipesHandlerTest_WithNested_Expected()
        {
            var recipes = Helpers.GetRecipes();

            var contextMock = new Mock<RecipeContext>(MockBehavior.Default, new DbContextOptions<RecipeContext>());
            contextMock.Setup(x => x.Recipes)
                .ReturnsDbSet(recipes);

            var query = new GetAllRecipesQuery(true);

            var handler = new GetAllRecipesHandler(contextMock.Object);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result.Data);
            Assert.NotEmpty(result.Data);
            Assert.True(result.IsSuccess);
            Assert.True(result.Data.Count() == 3);

            foreach (var recipe in result.Data)
            {
                Assert.NotEmpty(recipe.Instructions);
                Assert.NotEmpty(recipe.Ingredients);
            }
        }
    }
}
