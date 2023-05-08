using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Utilities
{
    public static class RecipeAPI
    {
        public const string Base = "https://localhost:7040/api/";

        public const string Recipes = "Recipes";
        public const string AllRecipes = $"{Recipes}/GetAll";
        public const string GetRecipe = $"{Recipes}/Get";
    }
}
