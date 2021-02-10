using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheCakeFactory.Models
{
    public interface ICookingStepRepository
    {
        IQueryable<CookingStep> CookingSteps { get; }
        void SaveCookingStep(CookingStep cookingStep);
        CookingStep DeleteCookingStep(int csId);
    }
}
