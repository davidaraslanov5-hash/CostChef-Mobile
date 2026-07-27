using System;
using System.Collections.Generic;
using System.Text;

namespace CostChef_Mobile.Models
{
    public class ModelOne
    {
        public List<Ingredient> ingredients = new List<Ingredient>();
        public class Ingredient
        { 
            public string Name { get; set; }
            public double? Price { get; set; }
            public double? UsedAmount { get; set; }
            public double? PackageSize { get; set; }
            public double Cost => Price / PackageSize * UsedAmount ?? 0;
        }

        public class Recipe
        {
            public string Name { get; set; }
            public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
            public double TotalCostRecipe => Ingredients.Sum(i => i.Cost);
        }
    }
}
