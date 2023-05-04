using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RfCommonLibrary.Enums
{
    public enum CategoryType
    {
        [Display(Name = "None")]
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
