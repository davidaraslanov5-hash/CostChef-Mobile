using System;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Mvvm.Input;
using CostChef_Mobile.Models;

namespace CostChef_Mobile.ViewModels
{
    internal partial class ViewModelOne : ObservableObject
    {
        ModelOne model = new ModelOne();
        public string Name { get; set; }
        public double Price { get; set; }
        public double UsedAmount { get; set; }
        public double PackageSize { get; set; }
        public double Cost { get; set; }

        [RelayCommand]
        public void CalculateCost(ModelOne.Ingredient ingredient)
        {
            Name = ingredient.Name;
            Price = ingredient.Price;
            UsedAmount = ingredient.UsedAmount;
            PackageSize = ingredient.PackageSize;
            Cost = ingredient.Cost;
        }
    }
}