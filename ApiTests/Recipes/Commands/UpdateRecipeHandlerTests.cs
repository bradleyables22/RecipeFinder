using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using RecipeAPI.Data;
using RecipeAPI.Recipes.Commands;
using RecipeAPI.Recipes.Handlers;
using RfCommonLibrary.Recipes.DatabaseModels;
using RfCommonLibrary.Recipes.DTOs.QueryDTOs;
using RfCommonLibrary.Recipes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTests.Recipes.Commands
{
    public class UpdateRecipeHandlerTests
    {
        [Fact]
        public async Task UpdateRecipeHandlerTest_Expected()
        {
            //var recipes = Helpers.GetRecipes();

            //var contextMock = new Mock<RecipeContext>(MockBehavior.Default, new DbContextOptions<RecipeContext>());
            //contextMock.Setup(x => x.Recipes)
            //    .ReturnsDbSet(recipes);

            //var r1 = recipes.First();
            //r1.Title = "Hello";

            //var command = new UpdateRecipeCommand(new RecipeDTO (r1));

            //var handler = new UpdateRecipeHandler(contextMock.Object);

            //// Act
            //var result = await handler.Handle(command, CancellationToken.None);

            ////// Assert
            ////Assert.NotNull(result.Data);
            ////Assert.True(result.IsSuccess);
            ////Assert.True(result.Data.Title == "Hello");
        }
    }
}
