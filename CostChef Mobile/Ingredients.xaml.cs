using System.Collections.ObjectModel;

namespace CostChef_Mobile;

public partial class Ingredients : ContentPage
{
    public Ingredients()
	{
		InitializeComponent();

		BindingContext = this;
	}

    public ObservableCollection<Models.ModelOne.Ingredient> SavedIngredients { get; set; } = new();

    protected override void OnAppearing()
    {
        base.OnAppearing();

        var loadedList = SimpleStorage.LoadData<ObservableCollection<Models.ModelOne.Ingredient>>("SavedItems")
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
            Price = 150,
            UsedAmount = 40,
            PackageSize = 140,
        };
        SavedIngredients.Add(newObj);

        SimpleStorage.SaveData("SavedItems", SavedIngredients);
    }

    private void DeleteAll_Clicked(object sender, EventArgs e)
    {
        SavedIngredients.Clear();
        SimpleStorage.SaveData("SavedItems", SavedIngredients);
    }
}