using ManagerApp.Models;
using ManagerApp.Services;
using ManagerApp.Utilities;
using MediatR;
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

            return View(new IndexViewModel { Recipes = recipeDTOs});
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}