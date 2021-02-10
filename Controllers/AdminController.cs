//Created by Clara Magaldi - 30109313

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheCakeFactory.Models;
using TheCakeFactory.Models.ViewModels;

namespace TheCakeFactory.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IRecipeRepository recipeRepository;
        private ICookingStepRepository cookingStepRepository;

        // Constructor
        public AdminController(IRecipeRepository recipeRepo, ICookingStepRepository cookingStepRepo) // repo is like an object of FakeProductRepository
        {
            recipeRepository = recipeRepo;
            cookingStepRepository = cookingStepRepo;
        }

        public ViewResult AddRecipe() => View("EditRecipe", new Recipe());

        [HttpGet]
        public ViewResult EditRecipe(int rId) => 
            View(recipeRepository.Recipes.FirstOrDefault(p => p.RecipeId == rId));

        [HttpPost]
        public IActionResult EditRecipe(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                recipeRepository.SaveRecipe(recipe);
                TempData["message"] = $"{recipe.Name} has been saved!";

                HomeRecipeDetailsViewModel homeRecipeDetailsViewModel = new HomeRecipeDetailsViewModel()
                {
                    Recipe = recipeRepository.Recipes
                                    .FirstOrDefault(r => r.RecipeId == recipe.RecipeId), //returns one Recipe object
                    ListOfCookingSteps = cookingStepRepository.CookingSteps
                                    .Where(c => c.RecipeId == recipe.RecipeId)
                                    .OrderBy(c => c.CookingStepNumber)
                                    .ToList() //returns an ordered list
                };
                return View("../Home/ViewRecipe", homeRecipeDetailsViewModel);
            }
            else
            {
                return View(recipe);
            }
        }
        public ViewResult DeleteRecipe(int rId)
        {
            List<CookingStep> ls = cookingStepRepository.CookingSteps.Where(x => x.RecipeId == rId).ToList();
            foreach (CookingStep cs in ls)
            {
                cookingStepRepository.DeleteCookingStep(cs.CookingStepId);
            }
            Recipe deletedRecipe = recipeRepository.DeleteRecipe(rId);
            if (deletedRecipe != null)
            {
                TempData["message"] = $"{deletedRecipe.Name} has been deleted!";
            }
            return View("../Home/RecipeList", recipeRepository.Recipes);
        }

        public ViewResult AddCookingStep(int rId) {
            int stepCount = cookingStepRepository.CookingSteps
                .Where(x => x.RecipeId == rId)
                .OrderByDescending(x => x.CookingStepNumber)
                .First()
                .CookingStepNumber;

            CookingStep cs = new CookingStep()
            {
                CookingStepNumber = stepCount + 1,
                RecipeId = rId,
                RecipeName = cookingStepRepository.CookingSteps
                    .FirstOrDefault(c => c.RecipeId == rId)
                    .RecipeName
            };
            return View("EditCookingStep", cs);
        } 
   
        [HttpGet]
        public ViewResult EditCookingStep(int csId) => View(cookingStepRepository.CookingSteps.FirstOrDefault(c => c.CookingStepId == csId));

        [HttpPost]
        public IActionResult EditCookingStep(CookingStep cookingStep)
        {
            if (ModelState.IsValid)
            {
                cookingStepRepository.SaveCookingStep(cookingStep);
                TempData["message"] = $"Step number {cookingStep.CookingStepNumber} has been saved!";
                
                return View("../Home/CookingStepList", cookingStepRepository.CookingSteps
                        .Where(c => c.RecipeId == cookingStep.RecipeId)
                        .OrderBy(c => c.CookingStepNumber)
                        .ToList());
            }
            else
            {
                return View(cookingStep);
            }
        }
        public ViewResult DeleteCookingStep(int csId)
        {
            int rId = cookingStepRepository.CookingSteps.FirstOrDefault(c => c.CookingStepId == csId).RecipeId;
            CookingStep deletedCookingStep = cookingStepRepository.DeleteCookingStep(csId);
            
            if (deletedCookingStep != null)
            {
                TempData["message"] = $"Step number {deletedCookingStep.CookingStepNumber} has been deleted!";
            }

            int existingCookingSteps = cookingStepRepository.CookingSteps
                .Where(c => c.RecipeId == rId)
                .OrderBy(c => c.CookingStepNumber)
                .ToList()
                .Count();

            if (existingCookingSteps == 0) // No remaining steps.
            {
                return View("EditRecipe", recipeRepository.Recipes.FirstOrDefault(r => r.RecipeId == rId));
            }
            else // Existing steps.
            {
                return View("../Home/CookingStepList", cookingStepRepository.CookingSteps
                    .Where(c => c.RecipeId == deletedCookingStep.RecipeId)
                    .OrderBy(c => c.CookingStepNumber)
                    .ToList());
            }
        }
    }
}
