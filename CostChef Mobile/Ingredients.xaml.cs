using CommunityToolkit.Mvvm.ComponentModel;
using CostChef_Mobile.ViewModels;
using System.Collections.ObjectModel;

namespace CostChef_Mobile;

public partial class Ingredients : ContentPage
{
    // Используем экземпляр ViewModel, а не обращаемся к нестатическому члену как к статическому
    private readonly ViewModels.ViewModelOne _viewModel = new ViewModels.ViewModelOne();

    public Ingredients()
	{
		InitializeComponent();
		BindingContext = this;
    }

    public ObservableCollection<Models.ModelOne.Recipe> SavedListRecipes { get; set; } = new();
    protected override void OnAppearing()
    {
        base.OnAppearing();

        var loadedList = SimpleStorage.LoadData<ObservableCollection<Models.ModelOne.Recipe>>("SavedItems")
                    ?? new ObservableCollection<Models.ModelOne.Recipe>();

        SavedListRecipes.Clear();

        foreach (var item in loadedList)
        {
            SavedListRecipes.Add(item);
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var newObj = new Models.ModelOne.Recipe
        {
            Name = "тест",
            Ingredients = _viewModel._SavedIngredients,
        };

        SavedListRecipes.Add(newObj);
        
        SimpleStorage.SaveData("SavedItems", SavedListRecipes);
    }
        
    private void DeleteAll_Clicked(object sender, EventArgs e)
    {
        SavedListRecipes.Clear();
        SimpleStorage.SaveData("SavedItems", SavedListRecipes);
    }
         
    public void CopyList()
    {
        foreach (var item in _viewModel.ListSavedReciepts)
        {
            SavedListRecipes.Add(item);
        }
    }
}