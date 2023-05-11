
using RfCommonLibrary.Recipes.DTOs.QueryDTOs;
using RfCommonLibrary.Recipes.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RfCommonLibrary.Recipes.DatabaseModels
{
    public class Ingredient
    {
        public Ingredient()
        {

        }
        public Ingredient(IngredientDTO dto)
        {
            IngredientID = dto.IngredientID;
            Name = dto.Name;
            Amount = dto.Amount;
            Unit = dto.Unit;
            RecipeID = dto.RecipeID;
        }

        [Key]
        public Guid IngredientID { get; set; } = Guid.NewGuid();
        [Required]
        [MaxLength(25)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public double Amount { get; set; } = 0;
        [Required]
        public MeasurementType Unit { get; set; } = MeasurementType.Unknown;

        [Required]
        [ForeignKey("Recipe")]
        public Guid RecipeID { get; set; }
        public Recipe? Recipe { get; set; }

    }
}
