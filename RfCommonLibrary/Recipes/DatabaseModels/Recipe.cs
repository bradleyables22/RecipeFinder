
using RfCommonLibrary.Recipes.DTOs.QueryDTOs;
using RfCommonLibrary.Recipes.Enums;
using System.ComponentModel.DataAnnotations;

namespace RfCommonLibrary.Recipes.DatabaseModels
{
    public class Recipe
    {
        public Recipe()
        {

        }
        public Recipe(RecipeDTO dto)
        {
            RecipeID = dto.RecipeID;
            Title = dto.Title;
            Description = dto.Description;
            Image = dto.Image;
            ExpenseRating = dto.ExpenseRating;
            PublishedAt = dto.PublishedAt;
            Category = dto.Category;
            Ingredients = dto.Ingredients.ToIngredientCollection();
            Instructions = dto.Instructions.ToInstructionCollection();
        }


        [Key]
        public Guid RecipeID { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(50)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string Description { get; set; } = string.Empty;
        [Required]
        [MaxLength]
        public string Image { get; set; } = string.Empty;
        public int? ExpenseRating { get; set; } = 0;
        [Required]
        public DateTime PublishedAt { get; set; } = DateTime.Now;
        [Required]
        public CategoryType Category { get; set; } = CategoryType.Everyone;
        public ICollection<Ingredient>? Ingredients { get; set; }
        public ICollection<Instruction>? Instructions { get; set; }
    }
}
