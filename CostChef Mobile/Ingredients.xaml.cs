using CommunityToolkit.Mvvm.ComponentModel;
using CostChef_Mobile.ViewModels;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;

namespace CostChef_Mobile;

public partial class Ingredients : ContentPage
{
    // Используем экземпляр ViewModel, а не обращаемся к нестатическому члену как к статическому
    //private readonly ViewModels.ViewModelOne _viewModel = new ViewModels.ViewModelOne();

    public Ingredients()
	{
        InitializeComponent();
		BindingContext = this;
    }

    public ObservableCollection<Models.ModelOne.Recipe> SavedListRecipes { get; set; } = new();

    public List<Models.ModelOne.Recipe> _savedRecipe { get; set; } = new();

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

    private void DeleteAll_Clicked(object sender, EventArgs e)
    {
        SavedListRecipes.Clear();

        SimpleStorage.Delete("SavedItems");
    }
}