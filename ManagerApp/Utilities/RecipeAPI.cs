namespace ManagerApp.Utilities
{
    public static class RecipeAPI
    {
        public const string Base = "https://localhost:7040/api/";

        public const string Recipes = "Recipes";
        public const string AllRecipes = $"{Recipes}/GetAll";
        public const string GetRecipe = $"{Recipes}/Get";
    }
}
