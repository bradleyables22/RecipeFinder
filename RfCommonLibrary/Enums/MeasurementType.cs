using System.ComponentModel.DataAnnotations;

namespace RfCommonLibrary.Enums
{
    public enum MeasurementType
    {
        [Display(Name = "")]
        Unknown,
        [Display(Name = "(g)")]
        Gram,
        [Display(Name = "(kg)")]
        Kilo,
        [Display(Name = "(oz)")]
        Ounce,
        [Display(Name = "(lb)")]
        Pound,
        [Display(Name = "(ml)")]
        MilliLiter,
        [Display(Name = "(L)")]
        Liter,
        [Display(Name = "(tsp)")]
        Teaspoon,
        [Display(Name = "(tbsp)")]
        TableSpoon,
        [Display(Name = "(fl oz)")]
        FluidOunce,
        [Display(Name = "(c)")]
        Cup,
        [Display(Name = "(pt)")]
        Pint,
        [Display(Name = "(qt)")]
        Quart,
        [Display(Name = "(gal)")]
        Gallon,
        [Display(Name = "Each")]
        Each,
        [Display(Name = "Dozen")]
        Dozen,
        [Display(Name = "Piece")]
        Peice,
        [Display(Name = "Dash")]
        Dash
    }
}
