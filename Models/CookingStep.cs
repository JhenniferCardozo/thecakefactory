using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheCakeFactory.Models
{
    public class CookingStep
    {
        public int CookingStepId { get; set; }
        public int CookingStepNumber { get; set; }
        [Required(ErrorMessage = "Please enter the description.")]
        public string Description { get; set; }
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
    }
}
