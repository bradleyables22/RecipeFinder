﻿using RfCommonLibrary.Recipes.DTOs.Manipulate;
using RfCommonLibrary.Recipes.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RfCommonLibrary.Recipes.DatabaseModels
{
    public class Recipe
    {
        public Recipe()
        {

        }
        public Recipe(AddEditRecipeDTO dto)
        {
            RecipeID = dto.RecipeID;
            Title = dto.Title;
            Description = dto.Description;
            Image = dto.Image;
            Category = dto.Category;
            PublishedAt = dto.PublishedAt;
            ExpenseRating = dto.ExpenseRating ?? 0;
        }


        [Key]
        public Guid RecipeID { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(50)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string Description { get; set; } = string.Empty;
        [Required]
        [MaxLength]
        public string Image { get; set; } = string.Empty;
        public int? ExpenseRating { get; set; } = 0;
        [Required]
        public DateTime PublishedAt { get; set; } = DateTime.Now;
        [Required]
        public CategoryType Category { get; set; } = CategoryType.Everyone;
        public ICollection<Ingredient>? Ingredients { get; set; }
        public ICollection<Instruction>? Instructions { get; set; }
    }
}
