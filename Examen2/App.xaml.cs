using Examen2.ViewModels;
using Examen2.Views;

namespace Examen2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var viewModel = new MainViewModels();
            MainPage = new NavigationPage(new MainPage(viewModel));

        }
    }
}
