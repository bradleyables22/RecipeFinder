using RfCommonLibrary.DatabaseModels;
using RfCommonLibrary.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RfCommonLibrary.DTOs.Manipulate
{
    public class AddEditIngredientDTO
    {
        [Required]
        public Guid IngredientID { get; set; } = Guid.NewGuid();
        [Required]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "MIN: 2, MAX: 25")]
        public string Name { get; set; } = string.Empty;
        [Required]
        public int Amount { get; set; } = 0;
        [Required]
        public MeasurementType Unit { get; set; } = MeasurementType.Unknown;

        [Required]
        public Guid RecipeID { get; set; }
    }
}
