using RfCommonLibrary.DatabaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RfCommonLibrary.DTOs.QueryDTOs
{
    public class InstructionDTO
    {
        public InstructionDTO()
        {
            
        }
        public InstructionDTO(Instruction? entity, bool includeParent = false)
        {
            if (entity != null)
            {
                InstructionID = entity.InstructionID;
                OrderNumber = entity.OrderNumber;
                Title = entity.Title;
                Info = entity.Info;
                RecipeID = entity.RecipeID;
                if (includeParent)
                    Recipe = entity.Recipe;
            }
        }

        public Guid InstructionID { get; set; }
        public int OrderNumber { get; set; } = 1;
        public string Title { get; set; } = string.Empty;
        public string Info { get; set; } = string.Empty;
        public Guid RecipeID { get; set; }
        public Recipe? Recipe { get; set; }
    }
}
