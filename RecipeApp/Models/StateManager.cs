using RfCommonLibrary.Recipes.DTOs.QueryDTOs;
using RfCommonLibrary.Recipes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public class StateManager
    {
        public CategoryType CategoryType { get; set; } = CategoryType.Everyone;
        public List<RecipeDTO>? Recipes { get; set; }
    }
}
