//Created by Clara Magaldi - 30109313

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheCakeFactory.Models
{
    public class Recipe
    {
        [Required(ErrorMessage ="Please enter the name.")]
        public string Name { get; set; }
        
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a valid preparation time.")]
        public int Preparation { get; set; }
        
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a valid cook time.")]
        public int Cook { get; set; }
        
        [Required(ErrorMessage = "Please enter the dificulty level.")]
        public string Dificulty { get; set; }
        
        [Required(ErrorMessage = "Please enter the ingredients.")]
        public string Ingredients { get; set; }
        //public string Description { get; set; }
        
        [Required(ErrorMessage = "Please enter the chef.")]
        public string Chef { get; set; }

        public int Stars { get; set; }
        
        public string Review { get; set; }
        
        public int RecipeId { get; set; }
    }
}
