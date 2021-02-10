using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheCakeFactory.Models.ViewModels
{
    public class HomeRecipeDetailsViewModel
    {
        public Recipe Recipe { get; set; }
        public List<CookingStep> ListOfCookingSteps { get; set; }
    }
}


