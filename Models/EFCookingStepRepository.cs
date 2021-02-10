using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheCakeFactory.Models
{
    public class EFCookingStepRepository : ICookingStepRepository
    {   
        // "context" will allow this repository to connect 
        //to the database and get data from it.
        private ApplicationDbContext context;

        // Constructor
        public EFCookingStepRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        
        public IQueryable<CookingStep> CookingSteps => context.CookingSteps;
        
        public void SaveCookingStep(CookingStep cookingStep)
        {
            if (cookingStep.CookingStepId == 0) // New product
            {
                context.CookingSteps.Add(cookingStep);
            }
            else // update
            {
                CookingStep stepEntry = context.CookingSteps.FirstOrDefault(s => s.CookingStepId == cookingStep.CookingStepId);
                if (stepEntry != null)
                {
                    stepEntry.CookingStepId = cookingStep.CookingStepId;
                    stepEntry.CookingStepNumber = cookingStep.CookingStepNumber;
                    stepEntry.Description = cookingStep.Description;
                    stepEntry.RecipeId = cookingStep.RecipeId;
                }
            }
            context.SaveChanges();
        }
        
        public CookingStep DeleteCookingStep(int csId)
        {
            CookingStep stepEntry = context.CookingSteps.FirstOrDefault(c => c.CookingStepId == csId);

            if (stepEntry != null)
            {
                context.CookingSteps.Remove(stepEntry);
                context.SaveChanges();
            }
            return stepEntry;
        }
    }
}
