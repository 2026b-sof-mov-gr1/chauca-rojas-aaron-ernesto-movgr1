using ExamenMovB1.Pages;

namespace ExamenMovB1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnVerPedidosTapped(object? sender, TappedEventArgs e) =>
            await Shell.Current.GoToAsync(nameof(PedidosPage));

        private async void OnComprarTapped(object? sender, TappedEventArgs e) =>
            await Shell.Current.GoToAsync(nameof(MenuPage));

        private async void OnAjustesClicked(object? sender, EventArgs e) =>
            await Shell.Current.GoToAsync(nameof(CuentaPage));
    }
}
