using RfCommonLibrary.Recipes.DatabaseModels;
using RfCommonLibrary.Recipes.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public Guid RecipeID { get; set; } = Guid.NewGuid();
        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "MIN: 5, MAX: 50")]
        public string Title { get; set; } = string.Empty;
        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "MIN: 5, MAX: 100")]
        public string Description { get; set; } = string.Empty;
        [Required]
        [StringLength(600, MinimumLength = 4, ErrorMessage = "MIN: 5, MAX: 600")]
        public string Image { get; set; } = string.Empty;
        [Range(1,5, ErrorMessage ="Outside of Range 1:5")]
        public int? ExpenseRating { get; set; }
        [Required]
        public DateTime PublishedAt { get; set; } = DateTime.Now;
        [Required]
        public CategoryType Category { get; set; } = CategoryType.Everyone;
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
