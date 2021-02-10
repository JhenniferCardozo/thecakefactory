//Created by Clara Magaldi - 30109313

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace TheCakeFactory.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();

            // Method that makes the migration scripts run automatically.
            // If the migration scripts have already run once, the database will not get migrated.
            // If it is the first time that the application is run, this method will ensure
            // that the application database is created and the correct tables get added to the database.
            context.Database.Migrate();
            if (!context.Recipes.Any())
            {

                context.Recipes.AddRange(
                    new Recipe
                    {
                        Name = "Lemon drizzle cake",
                        Preparation = 15,
                        Cook = 45,
                        Dificulty = "Easy",
                        Ingredients = "225g unsalted butter (softened);" +
                        "225g caster sugar, 4 eggs, 225g self-raising flour;" +
                        "finely grated zest 1 lemon. For the drizzle topping: juice 1½ lemons, 85g caster sugar;",
                        Chef = "Tana Ramsay",
                        Stars = 3
                    },
                    new Recipe
                    {
                        Name = "Ultimate chocolate cake",
                        Preparation = 40,
                        Cook = 90,
                        Dificulty = "Easy",
                        Ingredients = "For the chocolate cake:;" +
                        "200g dark chocolate (about 60% cocoa solids) chopped;" +
                        "200g butter (cubed);" +
                        "1 tbsp instant coffee granules;" +
                        "85g self-raising flour, 85g plain flour;" +
                        "¼ tsp bicarbonate of soda, 200g light muscovado sugar;" +
                        "200g golden caster sugar;" +
                        "25g cocoa powder;" +
                        "3 medium eggs, 75ml buttermilk;" +
                        "50g grated chocolate or 100g curls, to decorate;" +
                        "For the ganache:;" +
                        "200g dark chocolate(about 60 % cocoa solids) chopped;" +
                        "300ml double cream;" +
                        "2 tbsp golden caster sugar;",
                        Chef = "Angela Nilsen",
                        Stars = 4
                    },
                    new Recipe
                    {
                        Name = "Carrot cake",
                        Preparation = 15,
                        Cook = 60,
                        Dificulty = "Medium",
                        Ingredients = "175g light muscovado sugar;" +
                        "175ml sunflower oil;" +
                        "3 large eggs;" +
                        "lightly beaten;" +
                        "140g grated carrot (about 3 medium);" +
                        "100g raisins;" +
                        "grated zest of 1 large orange;" +
                        "175g self-raising flour;" +
                        "1 tsp bicarbonate of soda;" +
                        "1 tsp ground cinnamon;" +
                        "½ tsp grated nutmeg (freshly grated will give you the best flavour).;" +
                        "For the frosting:;" +
                        "175g icing sugar;" +
                        "1½-2 tbsp orange juice",
                        Chef = "Mary Cadogan",
                        Stars = 5
                    },
                    new Recipe
                    {
                        Name = "Best ever chocolate brownies",
                        Preparation = 26,
                        Cook = 35,
                        Dificulty = "Hard",
                        Ingredients = "185g unsalted butter;" +
                        "185g best dark chocolate;" +
                        "85g plain flour;" +
                        "40g cocoa powder;" +
                        "50g white chocolate;" +
                        "50g milk chocolate;" +
                        "3 large eggs;" +
                        "275g golden caster sugar",
                        Chef = "Orlando Murrin",
                        Stars = 5
                    }
                );
                context.CookingSteps.AddRange(
                    new CookingStep
                    {
                        CookingStepNumber = 1,
                        Description = "Heat oven to 180C/fan 160C/gas 4.",
                        //RecipeId = 4,
                        RecipeName = "Lemon drizzle cake"
                    },
                    new CookingStep
                    {
                        CookingStepNumber = 2,
                        Description = "Beat together 225g softened unsalted butter and 225g caster sugar until pale and creamy, then add 4 eggs, one at a time, slowly mixing through.",
                        //RecipeId = 4,
                        RecipeName = "Lemon drizzle cake"
                    },
                    new CookingStep
                    {
                        CookingStepNumber = 3,
                        Description = "Sift in 225g self-raising flour, then add the finely grated zest of 1 lemon and mix until well combined.",
                        //RecipeId = 4,
                        RecipeName = "Lemon drizzle cake"
                    },
                    new CookingStep
                    {
                        CookingStepNumber = 4,
                        Description = "Line a loaf tin(8 x 21cm) with greaseproof paper, then spoon in the mixture and level the top with a spoon.",
                        //RecipeId = 4,
                        RecipeName = "Lemon drizzle cake"
                    },
                    new CookingStep
                    {
                        CookingStepNumber = 5,
                        Description = "Bake for 45 - 50 mins until a thin skewer inserted into the centre of the cake comes out clean.",
                        //RecipeId = 4,
                        RecipeName = "Lemon drizzle cake"
                    },
                    new CookingStep
                    {
                        CookingStepNumber = 6,
                        Description = "While the cake is cooling in its tin, mix together the juice of 1 ½ lemons and 85g caster sugar to make the drizzle.",
                        //RecipeId = 4,
                        RecipeName = "Lemon drizzle cake"
                    },
                    new CookingStep
                    {
                        CookingStepNumber = 7,
                        Description = "Prick the warm cake all over with a skewer or fork, then pour over the drizzle – the juice will sink in and the sugar will form a lovely, crisp topping.",
                        //RecipeId = 4,
                        RecipeName = "Lemon drizzle cake"
                    },
                    new CookingStep
                    {
                        CookingStepNumber = 8,
                        Description = "Leave in the tin until completely cool, then remove and serve. Will keep in an airtight container for 3 - 4 days, or freeze for up to 1 month.;",
                        //RecipeId = 4,
                        RecipeName = "Lemon drizzle cake"
                    },
                    new CookingStep
                    {
                        CookingStepNumber = 1,
                        Description = "Heat the oven to 160C/ fan140C/ gas 3. Butter and line a 20cm round cake tin (7.5cm deep).",
                        //RecipeId = 3,
                        RecipeName = "Ultimate chocolate cake"
                    },
                    new CookingStep
                    {
                        CookingStepNumber = 2,
                        Description = "Put 200g chopped dark chocolate in a medium pan with 200g butter.",
                        //RecipeId = 3,
                        RecipeName = "Ultimate chocolate cake"
                    },
                    new CookingStep
                    {
                        CookingStepNumber = 3,
                        Description = "Mix 1 tbsp instant coffee granules into 125ml cold water and pour into the pan.",
                        //RecipeId = 3,
                        RecipeName = "Ultimate chocolate cake"
                    },
                    new CookingStep
                    {
                        CookingStepNumber = 4,
                        Description = "Warm through over a low heat just until everything is melted – don’t overheat. Or melt in the microwave for about 5 minutes, stirring halfway through.",
                        //RecipeId = 3,
                        RecipeName = "Ultimate chocolate cake"
                    },
                    new CookingStep
                    {
                        CookingStepNumber = 5,
                        Description = "Mix 85g self-raising flour, 85g plain flour, ¼ tsp bicarbonate of soda, 200g light muscovado sugar, 200g golden caster sugar and 25g cocoa powder, and squash out any lumps.",
                        //RecipeId = 3,
                        RecipeName = "Ultimate chocolate cake"
                    },
                    new CookingStep
                    {
                        CookingStepNumber = 6,
                        Description = "Beat 3 medium eggs with 75ml buttermilk.",
                        //RecipeId = 3,
                        RecipeName = "Ultimate chocolate cake"
                    },
                    new CookingStep
                    {
                        CookingStepNumber = 7,
                        Description = "Pour the melted chocolate mixture and the egg mixture into the flour mixture and stir everything to a smooth, quite runny consistency.",
                        //RecipeId = 3,
                        RecipeName = "Ultimate chocolate cake"
                    },
                    new CookingStep
                    {
                        CookingStepNumber = 8,
                        Description = "Pour this into the tin and bake for 1hr 25 – 1hr 30 mins.If you push a skewer into the centre it should come out clean and the top should feel firm(don’t worry if it cracks a bit).",
                        //RecipeId = 3,
                        RecipeName = "Ultimate chocolate cake"
                    },
                    new CookingStep
                    {
                        CookingStepNumber = 9,
                        Description = "Leave to cool in the tin(don’t worry if it dips slightly), then turn out onto a wire rack to cool completely.Cut the cold cake horizontally into three.",
                        //RecipeId = 3,
                        RecipeName = "Ultimate chocolate cake"
                    },
                    new CookingStep
                    {
                        CookingStepNumber = 10,
                        Description = "To make the ganache, put 200g chopped dark chocolate in a bowl. Pour 300ml double cream into a pan, add 2 tbsp golden caster sugar and heat until it is about to boil.",
                        //RecipeId = 3,
                        RecipeName = "Ultimate chocolate cake"
                    },
                    new CookingStep
                    {
                        CookingStepNumber = 11,
                        Description = "Take off the heat and pour it over the chocolate. Stir until the chocolate has melted and the mixture is smooth.Cool until it is a little thicker but still pourable.",
                        //RecipeId = 3,
                        RecipeName = "Ultimate chocolate cake"
                    },
                    new CookingStep
                    {
                        CookingStepNumber = 12,
                        Description = "Sandwich the layers together with just a little of the ganache.Pour the rest over the cake letting it fall down the sides and smooth over any gaps with a palette knife.",
                        //RecipeId = 3,
                        RecipeName = "Ultimate chocolate cake"
                    },
                    new CookingStep
                    {
                        CookingStepNumber = 13,
                        Description = "Decorate with 50g grated chocolate or 100g chocolate curls.The cake keeps moist and gooey for 3 - 4 days.",
                        //RecipeId = 3,
                        RecipeName = "Ultimate chocolate cake"
                    },
                    new CookingStep
                    {
                        CookingStepNumber = 1,
                        Description = "Heat the oven to 180C/fan160C/gas 4. Oil and line the base and sides of an 18cm square cake tin with baking parchment.",
                        //RecipeId = 2,
                        RecipeName = "Carrot cake"
                    },
                    new CookingStep
                    {
                        CookingStepNumber = 2,
                        Description = "Tip 175g light muscovado sugar, 175ml sunflower oil and 3 large beaten eggs into a big mixing bowl. Lightly mix with a wooden spoon. Stir in 140g grated carrots, 100g raisins and grated zest of 1 large orange.",
                        //RecipeId = 2,
                        RecipeName = "Carrot cake"
                    },
                    new CookingStep
                    {
                        CookingStepNumber = 3,
                        Description = "Sift 175g self-raising flour, 1 tsp bicarbonate of soda, 1 tsp ground cinnamon and ½ tsp grated nutmeg into the bowl. Mix everything together, the mixture will be soft and almost runny.",
                        //RecipeId = 2,
                        RecipeName = "Carrot cake"
                    },
                    new CookingStep
                    {
                        CookingStepNumber = 4,
                        Description = "Pour the mixture into the prepared tin and bake for 40-45 mins or until it feels firm and springy when you press it in the centre.",
                        //RecipeId = 2,
                        RecipeName = "Carrot cake"
                    },
                    new CookingStep
                    {
                        CookingStepNumber = 5,
                        Description = "Cool in the tin for 5 mins, then turn it out, peel off the paper and cool on a wire rack. (You can freeze the cake at this point if you want to serve it at a later date.);",
                        //RecipeId = 2,
                        RecipeName = "Carrot cake"
                    },
                    new CookingStep
                    {
                        CookingStepNumber = 6,
                        Description = "Beat 175g icing sugar and 1½ - 2 tbsp orange juice in a small bowl until smooth – you want the icing about as runny as single cream.",
                        //RecipeId = 2,
                        RecipeName = "Carrot cake"
                    },
                    new CookingStep
                    {
                        CookingStepNumber = 7,
                        Description = "Put the cake on a serving plate and boldly drizzle the icing back and forth in diagonal lines over the top, letting it drip down the sides.;",
                        //RecipeId = 2,
                        RecipeName = "Carrot cake"
                    },
                    new CookingStep
                    {
                        CookingStepNumber = 1,
                        Description = "Cut 185g unsalted butter into small cubes and tip into a medium bowl. Break 185g dark chocolate into small pieces and drop into the bowl.",
                        //RecipeId = 1,
                        RecipeName = "Best ever chocolate brownies"
                    },
                    new CookingStep
                    {
                        CookingStepNumber = 2,
                        Description = "Fill a small saucepan about a quarter full with hot water, then sit the bowl on top so it rests on the rim of the pan, not touching the water. Put over a low heat until the butter and chocolate have melted, stirring occasionally to mix them.",
                        //RecipeId = 1,
                        RecipeName = "Best ever chocolate brownies"
                    },
                    new CookingStep
                    {
                        CookingStepNumber = 3,
                        Description = "Remove the bowl from the pan. Alternatively, cover the bowl loosely with cling film and put in the microwave for 2 minutes on High.Leave the melted mixture to cool to room temperature.",
                        //RecipeId = 1,
                        RecipeName = "Best ever chocolate brownies"
                    },
                    new CookingStep
                    {
                        CookingStepNumber = 4,
                        Description = "While you wait for the chocolate to cool, position a shelf in the middle of your oven and turn the oven on to 180C / 160C fan / gas 4.",
                        //RecipeId = 1,
                        RecipeName = "Best ever chocolate brownies"
                    },
                    new CookingStep
                    {
                        CookingStepNumber = 5,
                        Description = "Using a shallow 20cm square tin, cut out a square of non-stick baking parchment to line the base.Tip 85g plain flour and 40g cocoa powder into a sieve held over a medium bowl.Tap and shake the sieve so they run through together and you get rid of any lumps.",
                        //RecipeId = 1,
                        RecipeName = "Best ever chocolate brownies"
                    },
                    new CookingStep
                    {
                        CookingStepNumber = 6,
                        Description = "Chop 50g white chocolate and 50g milk chocolate into chunks on a board.",
                        //RecipeId = 1,
                        RecipeName = "Best ever chocolate brownies"
                    },
                    new CookingStep
                    {
                        CookingStepNumber = 7,
                        Description = "Break 3 large eggs into a large bowl and tip in 275g golden caster sugar. With an electric mixer on maximum speed, whisk the eggs and sugar.They will look thick and creamy, like a milk shake.This can take 3 - 8 minutes, depending on how powerful your mixer is.You’ll know it’s ready when the mixture becomes really pale and about double its original volume. Another check is to turn off the mixer, lift out the beaters and wiggle them from side to side.If the mixture that runs off the beaters leaves a trail on the surface of the mixture in the bowl for a second or two, you’re there.",
                        //RecipeId = 1,
                        RecipeName = "Best ever chocolate brownies"
                    },
                    new CookingStep
                    {
                        CookingStepNumber = 8,
                        Description = "Pour the cooled chocolate mixture over the eggy mousse, then gently fold together with a rubber spatula. Plunge the spatula in at one side, take it underneath and bring it up the opposite side and in again at the middle. Continue going under and over in a figure of eight, moving the bowl round after each folding so you can get at it from all sides, until the two mixtures are one and the colour is a mottled dark brown. The idea is to marry them without knocking out the air, so be as gentle and slow as you like.",
                        //RecipeId = 1,
                        RecipeName = "Best ever chocolate brownies"
                    },
                    new CookingStep
                    {
                        CookingStepNumber = 9,
                        Description = "Hold the sieve over the bowl of eggy chocolate mixture and resift the cocoa and flour mixture, shaking the sieve from side to side, to cover the top evenly.",
                        //RecipeId = 1,
                        RecipeName = "Best ever chocolate brownies"
                    },
                    new CookingStep
                    {
                        CookingStepNumber = 10,
                        Description = "Gently fold in this powder using the same figure of eight action as before.The mixture will look dry and dusty at first, and a bit unpromising, but if you keep going very gently and patiently, it will end up looking gungy and fudgy.Stop just before you feel you should, as you don’t want to overdo this mixing.",
                        //RecipeId = 1,
                        RecipeName = "Best ever chocolate brownies"
                    },
                    new CookingStep
                    {
                        CookingStepNumber = 11,
                        Description = "Finally, stir in the white and milk chocolate chunks until they’re dotted throughout.",
                        //RecipeId = 1,
                        RecipeName = "Best ever chocolate brownies"
                    },
                    new CookingStep
                    {
                        CookingStepNumber = 12,
                        Description = "Pour the mixture into the prepared tin, scraping every bit out of the bowl with the spatula. Gently ease the mixture into the corners of the tin and paddle the spatula from side to side across the top to level it.",
                        //RecipeId = 1,
                        RecipeName = "Best ever chocolate brownies"
                    },
                    new CookingStep
                    {
                        CookingStepNumber = 13,
                        Description = "Put in the oven and set your timer for 25 mins.When the buzzer goes, open the oven, pull the shelf out a bit and gently shake the tin.If the brownie wobbles in the middle, it’s not quite done, so slide it back in and bake for another 5 minutes until the top has a shiny, papery crust and the sides are just beginning to come away from the tin.Take out of the oven.",
                        //RecipeId = 1,
                        RecipeName = "Best ever chocolate brownies"
                    },
                    new CookingStep
                    {
                        CookingStepNumber = 14,
                        Description = "Leave the whole thing in the tin until completely cold, then, if you’re using the brownie tin, lift up the protruding rim slightly and slide the uncut brownie out on its base.If you’re using a normal tin, lift out the brownie with the foil.Cut into quarters, then cut each quarter into four squares and finally into triangles.",
                        //RecipeId = 1,
                        RecipeName = "Best ever chocolate brownies"
                    },
                    new CookingStep
                    {
                        CookingStepNumber = 15,
                        Description = "They’ll keep in an airtight container for a good two weeks and in the freezer for up to a month.",
                        //RecipeId = 1,
                        RecipeName = "Best ever chocolate brownies"
                    }
                );
                context.SaveChanges();
                foreach (CookingStep cs in context.CookingSteps)
                {
                    cs.RecipeId = context.Recipes.FirstOrDefault(r => r.Name == cs.RecipeName).RecipeId;
                }
                context.SaveChanges();
            }
        }
    }
}
