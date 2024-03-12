using System;

namespace SumaAppMvvm
{
    public partial class MainPage : ContentPage
    {
        MainViewModel viewModel;

        public MainPage()
        {
            InitializeComponent();
            viewModel = new MainViewModel();
            BindingContext = viewModel;
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            viewModel.Limpiar();
        }
    }
}
