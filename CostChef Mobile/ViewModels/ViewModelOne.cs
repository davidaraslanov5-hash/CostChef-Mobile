using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CostChef_Mobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace CostChef_Mobile.ViewModels
{
    internal partial class ViewModelOne : ObservableObject
    {
        ModelOne model = new ModelOne();

        [ObservableProperty]
        public Color bcgColor = Color.FromArgb("#E1DDD0");
        [ObservableProperty]
        public Color inputColor = Color.FromArgb("#F1EDDC");
        [ObservableProperty]
        public Color buttonColor = Color.FromArgb("#936B61");
        [ObservableProperty]
        public Color listColor = Color.FromArgb("#EBEBEB");
        [ObservableProperty]
        public Color textColor = Microsoft.Maui.Graphics.Colors.Black;
        
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
        public bool isVisibleTotalCost = false;

        [ObservableProperty]
        ObservableCollection<ModelOne.Ingredient> ingredients = new ObservableCollection<ModelOne.Ingredient>();

        public List<ModelOne.Ingredient> _SavedIngredients { get; set; } = new List<ModelOne.Ingredient>();

        public ICommand DeleteCommand { get; set; }

        private void DeleteIngredient(ModelOne.Ingredient ingredient)
        {
            if (Ingredients.Contains(ingredient))
            {
                Ingredients.Remove(ingredient);
            }
            VisibleTotalCost();
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

                TotalCost = Ingredients.Sum(i => i.Cost);
                VisibleTotalCost();

                Name = string.Empty;
                Price = null;
                UsedAmount = null;
                PackageSize = null;
            }
        }

        public void VisibleTotalCost()
        {
            TotalCost = Ingredients.Sum(i => i.Cost);
            if (Ingredients.Count > 0)
            {
                IsVisibleTotalCost = true;
            }
            else
            {
                IsVisibleTotalCost = false;
            }
        }

        public TaskCompletionSource<string> _nameSetSignal = new();

        [RelayCommand]
        public async Task SaveIngredients()
        {
            /*while (NameFile == string.Empty)
            {
                await Task.Delay(70);
            }
            */
            string NameFile = await _nameSetSignal.Task;

            System.Diagnostics.Debug.WriteLine($"---> ИМЯ {NameFile}"); 

            _SavedIngredients = Ingredients.ToList();

            var reciept = new ModelOne.Recipe
            {
                Name = NameFile,
                Ingredients = _SavedIngredients
            };

            Ingredients.Clear();
            VisibleTotalCost();

            var currentSavedList = SimpleStorage.LoadData<List<ModelOne.Recipe>>("SavedItems") 
                                    ?? new List<ModelOne.Recipe>();

            currentSavedList.Add(reciept);

            _nameSetSignal = new TaskCompletionSource<string>();

            SimpleStorage.SaveData("SavedItems", currentSavedList);

        }

        [RelayCommand]
        public void loadIngredients()
        {
            var loadedIngredients = SimpleStorage.LoadData<ObservableCollection<ModelOne.Ingredient>>("Рецепт");
        }
    }
}