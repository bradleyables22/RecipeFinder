using RfCommonLibrary.Recipes.DatabaseModels;
using RfCommonLibrary.Recipes.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RfCommonLibrary.Recipes.DTOs.QueryDTOs
{
    public class RecipeDTO
    {
        public RecipeDTO()
        {

        }

        public RecipeDTO(Recipe r, bool includeNested = false)
        {
            RecipeID = r.RecipeID;
            Title = r.Title;
            Description = r.Description;
            Image = r.Image;
            PublishedAt = r.PublishedAt;
            Category = r.Category;
            ExpenseRating = r.ExpenseRating;
            if (includeNested)
            {
                Ingredients = r.Ingredients.FromIngredientCollection();
                Instructions = r.Instructions.FromInstructionCollection();
            }
        }

        [Required]
        public Guid RecipeID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public int? ExpenseRating { get; set; } = 0;
        public DateTime PublishedAt { get; set; } = DateTime.Now;
        public CategoryType Category { get; set; } = CategoryType.None;
        public ICollection<IngredientDTO>? Ingredients { get; set; }
        public ICollection<InstructionDTO>? Instructions { get; set; }

        [NotMapped]
        public string CategoryName
        {
            get
            {
                return Category.GetDisplayName();
            }
        }
    }
}
