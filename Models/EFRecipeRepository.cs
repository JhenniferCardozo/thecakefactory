//Created by Clara Magaldi - 30109313

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheCakeFactory.Models
{
    public class EFRecipeRepository : IRecipeRepository
    {
        // "context" will allow this repository to connect 
        // to the database and get data from it.
        private ApplicationDbContext context;

        // Constructor
        // Whenever we create an EFRecipeRepository, 
        // we give to it the connection to the database 
        // via the ApplicationDbContext.
        public EFRecipeRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        // Comes from the IRecipeRepository
        // Property Recipes (which is a dbset) from object 
        // context of type ApplicationDbContext.
        // Returns the set of recipes from the database.
        public IQueryable<Recipe> Recipes => context.Recipes;

        public void SaveRecipe(Recipe recipe) 
        {
            if (recipe.RecipeId == 0) // New product
            {
                context.Recipes.Add(recipe);
            }
            else 
            {
                Recipe recipeEntry = context.Recipes.FirstOrDefault(r => r.RecipeId == recipe.RecipeId);
                if (recipeEntry != null) 
                {
                    recipeEntry.Name = recipe.Name;
                    recipeEntry.Preparation = recipe.Preparation;
                    recipeEntry.Cook = recipe.Cook;
                    recipeEntry.Dificulty = recipe.Dificulty;
                    recipeEntry.Ingredients = recipe.Ingredients;
                    //recipeEntry.Description = recipe.Description;
                    recipeEntry.Chef = recipe.Chef;
                }
            }
            context.SaveChanges();
        }

        public Recipe DeleteRecipe(int rId)
        {
            Recipe recipeEntry = context.Recipes.FirstOrDefault(r => r.RecipeId == rId);

            if (recipeEntry != null)
            {
                context.Recipes.Remove(recipeEntry);
                context.SaveChanges();
            }
            return recipeEntry;
        }
    }
}

