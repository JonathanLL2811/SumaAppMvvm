
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace SumaAppMvvm
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private double _numero1;
        public double Numero1
        {
            get { return _numero1; }
            set
            {
                _numero1 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Numero1)));
            }
        }

        private double _numero2;
        public double Numero2
        {
            get { return _numero2; }
            set
            {
                _numero2 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Numero2)));
            }
        }

        public ICommand SumarCommand { get; }
        public ICommand LimpiarCommand { get; }

        public MainViewModel()
        {
            SumarCommand = new Command(Sumar);
            LimpiarCommand = new Command(Limpiar);
        }

        private async void Sumar()
        {
            if (Validar())
            {
                double resultado = Numero1 + Numero2;
                await App.Current.MainPage.DisplayAlert("Resultado", $"La suma es: {resultado}", "Aceptar");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Los campos deben ser numéricos y no pueden estar vacíos.", "Aceptar");
            }
        }

        private bool Validar()
        {
            return !string.IsNullOrEmpty(Numero1.ToString()) && !string.IsNullOrEmpty(Numero2.ToString()) && double.TryParse(Numero1.ToString(), out _) && double.TryParse(Numero2.ToString(), out _);
        }

        public void Limpiar()
        {
            Numero1 = 0;
            Numero2 = 0;
        }
    }
}
