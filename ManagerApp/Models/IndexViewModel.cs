using RfCommonLibrary.Recipes.DTOs.QueryDTOs;

namespace ManagerApp.Models
{
    public class IndexViewModel
    {
        public List<RecipeDTO> Recipes { get; set; } = new();
    }
}
