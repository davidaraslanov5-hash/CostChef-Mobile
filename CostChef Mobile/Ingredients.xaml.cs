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

    public ObservableCollection<Models.ModelOne.Ingredient> SavedIngredients { get; set; } = new();

    protected override void OnAppearing()
    {
        base.OnAppearing();

        var loadedList = SimpleStorage.LoadData<ObservableCollection<Models.ModelOne.Ingredient>>("Рецепт")
                    ?? new ObservableCollection<Models.ModelOne.Ingredient>();

        SavedIngredients.Clear();

        foreach (var item in loadedList)
        {
            SavedIngredients.Add(item);
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var newObj = new Models.ModelOne.Ingredient
        {
            Name = "тест",
            UsedAmount = 100,
            Price = 20,
        };

        SavedIngredients.Add(newObj);
        
        SimpleStorage.SaveData("SavedItems", SavedIngredients);
    }
        
    private void DeleteAll_Clicked(object sender, EventArgs e)
    {
        SavedIngredients.Clear();
        SimpleStorage.SaveData("SavedItems", SavedIngredients);
    }
         
    public void CopyList()
    {
        foreach (var item in _viewModel._SavedIngredients)
        {
            SavedIngredients.Add(item);
        }
    }
}