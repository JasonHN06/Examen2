namespace Examen2.Views;

public partial class MainPage : ContentPage
{
	public MainPage(ViewModels.MainViewModels viewModel)
	{
		InitializeComponent();
		BindingContext = new ViewModels.MainViewModels();
    }
}