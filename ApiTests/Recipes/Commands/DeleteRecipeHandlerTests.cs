using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using RecipeAPI.Data;
using RecipeAPI.Recipes.Commands;
using RecipeAPI.Recipes.Handlers;
using RfCommonLibrary.Recipes.DTOs.QueryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTests.Recipes.Commands
{
    public class DeleteRecipeHandlerTests
    {
        [Fact]
        public async Task DeleteRecipeHandlerTest_Expected()
        {
            var recipes = Helpers.GetRecipes();

            var contextMock = new Mock<RecipeContext>(MockBehavior.Loose, new DbContextOptions<RecipeContext>());
            contextMock.Setup(x => x.Recipes)
                .ReturnsDbSet(recipes);

            var id = recipes.Select(x => x.RecipeID).First();

            var command = new DeleteRecipeCommand(id);

            var handler = new DeleteRecipeHandler(contextMock.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result.Data);
            Assert.True(result.IsSuccess);
        }
    }
}
