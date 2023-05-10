using RecipeAPI.Controllers;
using RfCommonLibrary.Recipes.DatabaseModels;
using RfCommonLibrary.Recipes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTests
{
    public static class Helpers
    {
        public static List<Recipe> GetRecipes() 
        {
            return new List<Recipe>
            {
                new Recipe
                {
                    RecipeID = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    Title = "Title",
                    Description = "Description",
                    PublishedAt = DateTime.Now,
                    Category = CategoryType.Everyone,
                    ExpenseRating = 2,
                    Image = "Image",
                    Ingredients = GetIngredients("00000000-0000-0000-0000-000000000001"),
                    Instructions = GetInstructions("00000000-0000-0000-0000-000000000001")
                },
                new Recipe
                {
                    RecipeID = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    Title = "Title2",
                    Description = "Description2",
                    PublishedAt = DateTime.Now,
                    Category = CategoryType.Everyone,
                    ExpenseRating = 2,
                    Image = "Image2",
                    Ingredients = GetIngredients("00000000-0000-0000-0000-000000000002"),
                    Instructions = GetInstructions("00000000-0000-0000-0000-000000000002")
                },
                new Recipe
                {
                    RecipeID = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                    Title = "Title3",
                    Description = "Description3",
                    PublishedAt = DateTime.Now,
                    Category = CategoryType.Everyone,
                    ExpenseRating = 2,
                    Image = "Image3",
                    Ingredients = GetIngredients("00000000-0000-0000-0000-000000000003"),
                    Instructions = GetInstructions("00000000-0000-0000-0000-000000000003")
                }

            };
        }
        public static List<Ingredient> GetIngredients(string id) 
        {
            return new List<Ingredient>
            { 
                new Ingredient 
                {
                    RecipeID = Guid.Parse(id),
                    IngredientID = Guid.NewGuid(),
                    Amount = 1,
                    Name = "test",
                    Unit = MeasurementType.Unknown
                }
                
            };
        }
        public static List<Instruction> GetInstructions(string id)
        {
            return new List<Instruction>
            {
                new Instruction
                {
                    RecipeID = Guid.Parse(id),
                    InstructionID = Guid.NewGuid(),
                    Info = "Test",
                    Title = "test",
                    OrderNumber = 1
                }

            };
        }
    }
}
