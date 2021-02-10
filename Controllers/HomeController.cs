using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using TheCakeFactory.Models;
using TheCakeFactory.Models.ViewModels;

namespace TheCakeFactory.Controllers
{
    public class HomeController : Controller
    {
        //Field
        private IRecipeRepository recipeRepository;
        private ICookingStepRepository cookingStepRepository;

        // Constructor
        public HomeController(IRecipeRepository recipeRepo, ICookingStepRepository cookingStepRepo) // repo is like an object of FakeProductRepository
        {
            recipeRepository = recipeRepo;
            cookingStepRepository = cookingStepRepo;
        }

        //default action method
        public ViewResult Index() => View();

        public ViewResult RecipeList() => View(recipeRepository.Recipes);

        public ViewResult CookingStepList(int rId)
        {
            int existingCookingSteps = cookingStepRepository.CookingSteps
                .Where(c => c.RecipeId == rId)
                .OrderBy(c => c.CookingStepNumber)
                .ToList()
                .Count();
            if(existingCookingSteps == 0) // recipe exists but has no cooking steps.
            {
                CookingStep cs = new CookingStep()
                {
                    CookingStepNumber = 1,
                    RecipeId = rId,
                    RecipeName = recipeRepository.Recipes
                        .FirstOrDefault(r => r.RecipeId == rId)
                        .Name
                };
                return View("../Admin/EditCookingStep", cs);
            }
            else // Recipe exists and has one or more cooking steps.
            {
                return View(cookingStepRepository.CookingSteps
                    .Where(c => c.RecipeId == rId)
                    .OrderBy(c => c.CookingStepNumber)
                    .ToList()); // Sends an ordered list.
            }
        } 

            
        public ViewResult ViewRecipe(int rId) =>
            View(new HomeRecipeDetailsViewModel()
                {
                    Recipe = recipeRepository.Recipes
                                    .FirstOrDefault(r => r.RecipeId == rId), //returns one Recipe object
                    ListOfCookingSteps = cookingStepRepository.CookingSteps
                                    .Where(c => c.RecipeId == rId)
                                    .OrderBy(c => c.CookingStepNumber)
                                    .ToList() //returns an ordered list
                }
           );

        public ViewResult ReviewRecipe(int rId) // action
        {
            return View(recipeRepository.Recipes.FirstOrDefault(r => r.RecipeId == rId));
        }
    }
}
