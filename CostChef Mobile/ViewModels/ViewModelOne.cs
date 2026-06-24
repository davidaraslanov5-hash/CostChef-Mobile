using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CostChef_Mobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace CostChef_Mobile.ViewModels
{
    internal partial class ViewModelOne : ObservableObject
    {
        ModelOne model = new ModelOne();

        [ObservableProperty]
        public Color interactColor = Colors.Pink;
        [ObservableProperty] 
        public Color color = Colors.MintCream;
        [ObservableProperty]
        public Color textColor = Colors.Black;
        [ObservableProperty]
        public Color backgroundColor = Colors.LightPink;

        [ObservableProperty]
        private string name = string.Empty;
        [ObservableProperty]
        public double? price;
        [ObservableProperty]
        public double? usedAmount;
        [ObservableProperty]
        public double? packageSize;
        [ObservableProperty]
        public double? cost;

        [ObservableProperty]
        public double? totalCost;

        [ObservableProperty]
        ObservableCollection<ModelOne.Ingredient> ingredients = new ObservableCollection<ModelOne.Ingredient>();

        public ICommand DeleteCommand { get; set; }

        private void DeleteIngredient(ModelOne.Ingredient ingredient)
        {
            if (Ingredients.Contains(ingredient))
            {
                Ingredients.Remove(ingredient);
            }
        }

        [RelayCommand]
        public void CalculateCost()
        {
            if (Name == string.Empty ||
                Price == null ||
                UsedAmount == null ||
                PackageSize == null) ;
            else
            {
                var ingredient = new ModelOne.Ingredient
                {
                    Name = Name,
                    Price = Price,
                    UsedAmount = UsedAmount,
                    PackageSize = PackageSize
                };

                DeleteCommand = new RelayCommand<ModelOne.Ingredient>(DeleteIngredient);

                Cost = ingredient.Cost;
                Ingredients.Add(ingredient);
                TotalCost += ingredient.Cost;

                Name = string.Empty;
                Price = null;
                UsedAmount = null;
                PackageSize = null;
            }
        }

    }
}