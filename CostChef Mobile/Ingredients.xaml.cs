using CommunityToolkit.Mvvm.ComponentModel;
using CostChef_Mobile.ViewModels;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;


namespace CostChef_Mobile;

public partial class Ingredients : ContentPage
{
    // Используем экземпляр ViewModel, а не обращаемся к нестатическому члену как к статическому
    private readonly ViewModels.IngredientsViewModel _viewModel;


    public Ingredients()
	{
        InitializeComponent();
        _viewModel = new ViewModels.IngredientsViewModel();
        BindingContext = _viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.LoadRecipes();
    }
}