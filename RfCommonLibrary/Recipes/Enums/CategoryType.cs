using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RfCommonLibrary.Recipes.Enums
{
    public enum CategoryType
    {
        [Display(Name = "For Everyone")]
        None,
        [Display(Name = "Vegan")]
        Vegan,
        [Display(Name = "Vegitarian")]
        Vegitarian,
        [Display(Name = "Dairy-Free")]
        NonDairy,
        [Display(Name = "Kosher")]
        Kosher,
        [Display(Name = "Halal")]
        Halal
    }
}
