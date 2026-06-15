using System;
using System.Collections.Generic;
using System.Text;

namespace CostChef_Mobile.Models
{
    internal class ModelOne
    {

        public class Ingredient
        {
            public string Name { get; set; }
            public double Price { get; set; }
            public double UsedAmount { get; set; }
            public double PackageSize { get; set; }

            public double Cost => Price / PackageSize * UsedAmount;
        }

    }
}
