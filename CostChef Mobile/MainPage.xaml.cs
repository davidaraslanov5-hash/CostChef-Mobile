namespace CostChef_Mobile
{
    public partial class MainPage : ContentPage
    {
        private readonly ViewModels.ViewModelOne _viewModel;
        public MainPage()
        {
            InitializeComponent();
            _viewModel = new ViewModels.ViewModelOne();
            BindingContext = _viewModel;
        }



        private async void SetNameToSave(object sender, EventArgs e)
        {
            string NameList = await DisplayPromptAsync(
                "Сохранить ингредиенты",
                "Введите имя для списка ингредиентов",
                accept: "Сохранить",
                cancel: "Отмена",
                placeholder: "Имя списка",
                maxLength: 50,
                keyboard: Keyboard.Text
                );
            //_viewModel.NameFile = NameList;
            _viewModel._nameSetSignal.TrySetResult(NameList);
        }
        
    }
}
