using RfCommonLibrary.Recipes.DatabaseModels;
using RfCommonLibrary.Recipes.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
        [Required]
        public Guid IngredientID { get; set; } = Guid.NewGuid();
        [Required]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "MIN: 2, MAX: 25")]
        public string Name { get; set; } = string.Empty;
        [Required]
        public double Amount { get; set; } = 0;
        [Required]
        public MeasurementType Unit { get; set; } = MeasurementType.Unknown;
        [Required]
        public Guid RecipeID { get; set; }
        [JsonIgnore]
        public Recipe? Recipe { get; set; }
    }
}
