using RfCommonLibrary.Recipes.DatabaseModels;
using RfCommonLibrary.Recipes.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RfCommonLibrary.Recipes.DTOs.QueryDTOs
{
    public class IngredientDTO
    {
        public IngredientDTO()
        {

        }

        public IngredientDTO(Ingredient? entity, bool includeParent = false)
        {
            if (entity != null)
            {
                IngredientID = entity.IngredientID;
                Name = entity.Name;
                Amount = entity.Amount;
                Unit = entity.Unit;
                RecipeID = entity.RecipeID;
                if (includeParent)
                    Recipe = entity.Recipe;
            }
        }

        public Guid IngredientID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Amount { get; set; } = 0;
        public MeasurementType Unit { get; set; } = MeasurementType.Unknown;
        public Guid RecipeID { get; set; }
        public Recipe? Recipe { get; set; }
    }
}
