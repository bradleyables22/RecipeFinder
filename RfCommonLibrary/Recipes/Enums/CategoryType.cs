using System.ComponentModel.DataAnnotations;
namespace RfCommonLibrary.Recipes.Enums
{
    public enum CategoryType
    {
        [Display(Name = "For Everyone")]
        Everyone,
        [Display(Name = "Vegan")]
        Vegan,
        [Display(Name = "Vegetarian")]
        Vegetarian,
        [Display(Name = "Dairy-Free")]
        NonDairy,
        [Display(Name = "Kosher")]
        Kosher,
        [Display(Name = "Halal")]
        Halal
    }
}
