using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CostChef_Mobile.ViewModels
{
    internal partial class IngredientsViewModel : ObservableObject
    {
        ColorsViewModel colors = new ColorsViewModel();

        [ObservableProperty]
        public Color bcgColor;

        [ObservableProperty]
        public Color inputColor;

        [ObservableProperty]
        public Color buttonColor;

        [ObservableProperty]
        public Color listColor;

        [ObservableProperty]
        public Color textColor = Microsoft.Maui.Graphics.Colors.Black;

        public IngredientsViewModel()
        {
            bcgColor = colors.bcgColor;
            inputColor = colors.inputColor;
            buttonColor = colors.buttonColor;
            listColor = colors.listColor;
        }

        public ObservableCollection<Models.ModelOne.Recipe> SavedListRecipes { get; set; } = new();

        public List<Models.ModelOne.Recipe> _savedRecipe { get; set; } = new();

        public void LoadRecipes()
        {
            var loadedList = SimpleStorage.LoadData<ObservableCollection<Models.ModelOne.Recipe>>("SavedItems")
                        ?? new ObservableCollection<Models.ModelOne.Recipe>();

            SavedListRecipes.Clear();

            foreach (var item in loadedList)
            {
                SavedListRecipes.Add(item);
            }

        }

        [RelayCommand]
        public void DeleteAll()
        {
            SavedListRecipes.Clear();
            SimpleStorage.Delete("SavedItems");
        }
    }
}
