using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2.ViewModels
{
    public partial class MainViewModels : ObservableObject
    {
        [ObservableProperty]
        private string producto1;

        [ObservableProperty]
        private string producto2;

        [ObservableProperty]
        private string producto3;

        [ObservableProperty]
        private double subtotal;

        [ObservableProperty]
        private double descuento;

        [ObservableProperty]
        private double total;

        [RelayCommand]
        public void Calcular()
        {
            try
            {
                double p1 = string.IsNullOrWhiteSpace(producto1) ? 0 : Convert.ToDouble(producto1);
                double p2 = string.IsNullOrWhiteSpace(producto2) ? 0 : Convert.ToDouble(producto2);
                double p3 = string.IsNullOrWhiteSpace(producto3) ? 0 : Convert.ToDouble(producto3);

                subtotal = p1 + p2 + p3;
                descuento = ObtenerDescuento(subtotal);
                total = subtotal - (subtotal * descuento / 100);
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Error", $"Por favor, ingrese valores validos: {ex.Message}", "OK");
            }
        }

        private double ObtenerDescuento(double subtotal)
        {
            if (subtotal >= 1000 && subtotal <= 4999.99) return 10;
            if (subtotal >= 5000 && subtotal <= 9999.99) return 20;
            if (subtotal >= 10000 && subtotal <= 19999.99) return 30;
            return 0;
        }

        [RelayCommand]
        public void Limpiar()
        {
            producto1 = producto2 = producto3 = string.Empty;
            subtotal = descuento = total = 0;
        }
    }
}
