namespace CostChef_Mobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            BindingContext = new ViewModels.ViewModelOne();
            InitializeComponent();
        }
    }
}
