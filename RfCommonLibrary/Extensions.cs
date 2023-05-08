using RfCommonLibrary.Recipes.DatabaseModels;
using RfCommonLibrary.Recipes.DTOs.QueryDTOs;
using RfCommonLibrary.Utilities;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace RfCommonLibrary
{
    public static class Extensions
    {

        #region DB Transforms
        public static ICollection<Instruction>? ToInstructionCollection(this ICollection<InstructionDTO>? instructions)
        {
            if (instructions == null)
                return null;

            var dtos = new List<Instruction>();
            foreach (var instruction in instructions)
            {
                dtos.Add(new Instruction(instruction));
            }
            return dtos;
        }
        public static ICollection<Ingredient>? ToIngredientCollection(this ICollection<IngredientDTO>? ingredients)
        {
            if (ingredients == null)
                return null;

            var dtos = new List<Ingredient>();
            foreach (var ingredient in ingredients)
            {
                dtos.Add(new Ingredient(ingredient));
            }
            return dtos;
        }
        public static ICollection<InstructionDTO>? FromInstructionCollection(this ICollection<Instruction>? instructions)
        {
            if (instructions == null)
                return null;

            var dtos = new List<InstructionDTO>();
            foreach (var instruction in instructions)
            {
                dtos.Add(new InstructionDTO(instruction));
            }
            return dtos;
        }
        public static ICollection<IngredientDTO>? FromIngredientCollection(this ICollection<Ingredient>? ingredients)
        {

            if (ingredients == null)
                return null;

            var dtos = new List<IngredientDTO>();
            foreach (var ingredient in ingredients)
            {
                dtos.Add(new IngredientDTO(ingredient));
            }
            return dtos;
        }

        #endregion

        #region Result Objects
        public static Result<T> Ensure<T>(this Result<T> result, Func<T, bool> predicate, string? error = null)
        {
            if (result.IsFailure)
                return result;

            if (predicate(result.Data))
                return result;

            string e = error ?? @$"The predicate function ""{predicate.Method.Name}"" returned false.";

            return result.Failure(e);
        }
        public static Result<T> ToResult<T>(this T obj)
        {
            return new Result<T> { Data = obj };
        }

        #endregion

        #region Random
        public static string GetDisplayName(this Enum enumValue)
        {
            var name =  enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            .GetName();

            return name ?? "";

        }
        #endregion
    }

}
