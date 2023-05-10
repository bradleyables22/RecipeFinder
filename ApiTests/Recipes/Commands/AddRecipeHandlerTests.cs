using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using RecipeAPI.Data;
using RecipeAPI.Recipes.Commands;
using RecipeAPI.Recipes.Handlers;
using RecipeAPI.Recipes.Queries;
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
    public class AddRecipeHandlerTests
    {
        [Fact]
        public async Task AddRecipeHandlerTest_Expected()
        {
            var recipes = Helpers.GetRecipes();

            var contextMock = new Mock<RecipeContext>(MockBehavior.Default, new DbContextOptions<RecipeContext>());
            contextMock.Setup(x => x.Recipes)
                .ReturnsDbSet(recipes);

            var newRecipe = new Recipe
            {
                RecipeID = Guid.Parse("01000000-0000-0000-0000-000000000001"),
                Title = "testsss",
                Description = "Description",
                Image = "testrrrr",
                Category = CategoryType.Vegan,
                ExpenseRating = 1,
                PublishedAt = DateTime.Now,
                Ingredients = new List<Ingredient> 
                {
                    new Ingredient
                    {
                        IngredientID = Guid.NewGuid(),
                        RecipeID = Guid.Parse("01000000-0000-0000-0000-000000000001"),
                        Amount = 1,
                        Name = "Namerrertw",
                        Unit = MeasurementType.Gram
                    }
                },
                Instructions = new List<Instruction>
                {
                    new Instruction
                    {
                        InstructionID = Guid.NewGuid(),
                        RecipeID = Guid.Parse("01000000-0000-0000-0000-000000000001"),
                        Info = "Testertwer",
                        OrderNumber = 1,
                        Title = "Titleerwtwer"
                    }
                }
            };

            RecipeDTO dto = new RecipeDTO(newRecipe, true);

            var command = new AddRecipeCommand(dto);

            var handler = new AddRecipeHandler(contextMock.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result.Data);
            Assert.True(result.IsSuccess);
            Assert.NotEmpty(result.Data.Ingredients);
            Assert.NotEmpty(result.Data.Instructions);
        }
    }
}
