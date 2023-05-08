using RfCommonLibrary.Recipes.DTOs.Manipulate;
using RfCommonLibrary.Recipes.DTOs.QueryDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RfCommonLibrary.Recipes.DatabaseModels
{
    public class Instruction
    {
        public Instruction()
        {

        }
        public Instruction(InstructionDTO dto)
        {
            InstructionID = dto.InstructionID;
            Title = dto.Title;
            Info = dto.Info;
            RecipeID = dto.RecipeID;
            OrderNumber = dto.OrderNumber;
        }

        [Key]
        public Guid InstructionID { get; set; } = Guid.NewGuid();
        [Required]
        public int OrderNumber { get; set; } = 1;
        [Required]
        [MaxLength(50)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MaxLength(300)]
        public string Info { get; set; } = string.Empty;

        [Required]
        [ForeignKey("Recipe")]
        public Guid RecipeID { get; set; }
        public Recipe? Recipe { get; set; }
    }
}
