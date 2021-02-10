//Created by Clara Magaldi - 30109313

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheCakeFactory.Models
{
    public interface IRecipeRepository
    {
        IQueryable<Recipe> Recipes { get; }
        void SaveRecipe(Recipe recipe);
        Recipe DeleteRecipe(int rId);
    }
}
