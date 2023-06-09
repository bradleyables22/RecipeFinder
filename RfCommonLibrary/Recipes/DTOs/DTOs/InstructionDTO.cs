﻿using RfCommonLibrary.Recipes.DatabaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RfCommonLibrary.Recipes.DTOs.QueryDTOs
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
        [Required]
        public Guid InstructionID { get; set; } = Guid.NewGuid();
        [Required]
        public int OrderNumber { get; set; } = 1;
        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "MIN: 5, MAX: 50")]
        public string Title { get; set; } = string.Empty;
        [Required]
        [StringLength(300, MinimumLength = 10, ErrorMessage = "MIN: 10, MAX: 300")]
        public string Info { get; set; } = string.Empty;
        [Required]
        public Guid RecipeID { get; set; }

        [JsonIgnore]
        public Recipe? Recipe { get; set; }
    }
}
