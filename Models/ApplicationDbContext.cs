//Created by Clara Magaldi - 30109313

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TheCakeFactory.Models
{
    public class ApplicationDbContext : DbContext
    {
        // Constructor
        // We are sending the options to the base class (DbContext).
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) { }

        // Property
        // We need a property to get the set of products.
        // We defined this as a dataset of products.
        // We are going to get the product dataset from the database via the Products property.
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<CookingStep> CookingSteps { get; set; }
    }
}


