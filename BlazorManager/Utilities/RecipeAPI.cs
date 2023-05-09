namespace BlazorManager.Utilities
{
    public class RecipeAPI
    {
        public const string Base = "https://localhost:7040/api/";
        public const string Recipes = "Recipes";
        public const string AllRecipes = $"{Recipes}/GetAll";
        public const string GetRecipe = $"{Recipes}/Get";
        public const string DeleteRecipe = $"{Recipes}/Delete";
        public const string AddRecipe = $"{Recipes}/Create";
        public const string UpdateRecipe = $"{Recipes}/Update";
    }
}
