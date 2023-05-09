using ManagerApp.Models;
using ManagerApp.Services;
using ManagerApp.Utilities;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using RfCommonLibrary.Recipes.DTOs.QueryDTOs;
using System.Diagnostics;

namespace ManagerApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IClientService _clientService;
        public HomeController(ILogger<HomeController> logger, IClientService client)
        {
            _logger = logger;
            _clientService = client;
        }

        
        public async Task<IActionResult> Index()
        {

            RestRequest request = new RestRequest(RecipeAPI.AllRecipes);
            List<RecipeDTO> recipeDTOs = new();
            var result = await _clientService.TryGetAsync<List<RecipeDTO>>(request);
            if (result.IsFailure)
            {
                return View(new IndexViewModel { Recipes = recipeDTOs });
            }
            recipeDTOs = result.Data;

            if (TempData.ContainsKey("ErrorMessage"))
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"].ToString();
            }
            if (TempData.ContainsKey("SuccessMessage"))
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();
            }
            TempData.Clear();
            return View(new IndexViewModel { Recipes = recipeDTOs});
        }

        [HttpPost]
        public async Task<IActionResult> Index(string id)
        {

            RestRequest request = new RestRequest(RecipeAPI.DeleteRecipe, Method.Delete);
            request.AddHeader("recipeID", id);
            
            List<RecipeDTO> recipeDTOs = new();
            var result = await _clientService.TryDeleteAsync<RecipeDTO>(request);
            if (result.IsFailure)
                TempData["ErrorMessage"] = "Delete Failure";
            else
                TempData["SuccessMessage"] = "Delete Successful";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            RestRequest request = new RestRequest(RecipeAPI.GetRecipe);
            request.AddHeader("recipeID", id);
            request.AddHeader("includeNested", true);
            RecipeDTO dto = new();
            var result = await _clientService.TryGetAsync<RecipeDTO>(request);
            if (result.IsFailure)
            {
                return NotFound();
            }
            if (TempData.ContainsKey("ErrorMessage"))
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"].ToString();
            }
            TempData.Clear();
            
            dto = result.Data;

            return View(new EditViewModel { Recipe = dto });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RecipeDTO recipe)
        {
            RestRequest request = new RestRequest(RecipeAPI.UpdateRecipe);
            request.AddBody(recipe);
            RecipeDTO dto = new();
            var result = await _clientService.TryGetAsync<RecipeDTO>(request);
            if (result.IsFailure) 
            {
                TempData["ErrorMessage"] = "Update Failure";
                return RedirectToAction("Edit", new { id = recipe.RecipeID.ToString() });
            }
            TempData["SuccessMessage"] = "Update Successful";
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}