using RfCommonLibrary.Recipes.Enums;
using System.ComponentModel.DataAnnotations;

namespace RfCommonLibrary.Recipes.DTOs.Manipulate
{
    public class AddEditRecipeDTO
    {
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
        public int? ExpenseRating { get; set; } = 0;
        [Required]
        public DateTime PublishedAt { get; set; } = DateTime.Now;
        [Required]
        public CategoryType Category { get; set; } = CategoryType.None;

    }
}
