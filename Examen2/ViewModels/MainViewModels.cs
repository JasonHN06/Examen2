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
                double p1 = string.IsNullOrWhiteSpace(Producto1) ? 0 : Convert.ToDouble(Producto1);
                double p2 = string.IsNullOrWhiteSpace(Producto2) ? 0 : Convert.ToDouble(Producto2);
                double p3 = string.IsNullOrWhiteSpace(Producto3) ? 0 : Convert.ToDouble(Producto3);

                Subtotal = p1 + p2 + p3;
                Descuento = ObtenerDescuento(Subtotal);
                Total = Subtotal - (Subtotal * Descuento / 100);
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
            Producto1 = Producto2 = Producto3 = string.Empty;
            Subtotal = Descuento = Total = 0;
        }
    }
}
